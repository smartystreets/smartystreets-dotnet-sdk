using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SmartyStreets
{
    using NUnit.Framework;

    /// <summary>
    ///     The sync Send() methods block on SendAsync(). If any await inside the SDK captures the
    ///     caller's SynchronizationContext, a single-threaded context (classic ASP.NET, WinForms,
    ///     WPF) deadlocks: the continuation is posted to the context whose only thread is blocked
    ///     waiting for it. NUnit has no SynchronizationContext, so these tests install one.
    /// </summary>
    [TestFixture]
    public class SyncOverAsyncTests
    {
        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(5);

        [Test]
        public void TestSyncSendDoesNotDeadlockOnSingleThreadedSynchronizationContext()
        {
            var client = new ClientBuilder("test-id", "test-token")
                .WithHttpClient(new HttpClient(new YieldingHandler()))
                .WithSerializer(new FakeSerializer(null))
                .BuildUsStreetApiClient();

            var completed = CompletesOnSingleThreadedContext(
                () => client.Send(new USStreetApi.Lookup("1 Rosedale")));

            Assert.IsTrue(completed, "Send() deadlocked on a single-threaded SynchronizationContext.");
        }

        private static bool CompletesOnSingleThreadedContext(Action action)
        {
            Exception error = null;
            var done = new ManualResetEventSlim();

            // Background thread so a deadlocked run doesn't keep the test process alive.
            var thread = new Thread(() =>
            {
                var context = new SingleThreadSynchronizationContext();
                SynchronizationContext.SetSynchronizationContext(context);
                context.Post(_ =>
                {
                    try { action(); }
                    catch (Exception e) { error = e; }
                    finally
                    {
                        done.Set();
                        context.Complete();
                    }
                }, null);
                context.RunOnCurrentThread();
            }) { IsBackground = true };
            thread.Start();

            var completed = done.Wait(Timeout);
            if (error != null)
                throw new AssertionException("Send() threw: " + error);
            return completed;
        }

        /// <summary>
        ///     Mimics a UI or classic ASP.NET context: posted callbacks run one at a time on a
        ///     single dedicated thread.
        /// </summary>
        private sealed class SingleThreadSynchronizationContext : SynchronizationContext
        {
            private readonly BlockingCollection<KeyValuePair<SendOrPostCallback, object>> queue =
                new BlockingCollection<KeyValuePair<SendOrPostCallback, object>>();

            public override void Post(SendOrPostCallback d, object state)
            {
                queue.Add(new KeyValuePair<SendOrPostCallback, object>(d, state));
            }

            public void RunOnCurrentThread()
            {
                foreach (var item in queue.GetConsumingEnumerable())
                    item.Key(item.Value);
            }

            public void Complete()
            {
                queue.CompleteAdding();
            }
        }

        /// <summary>
        ///     Completes asynchronously, like a real network call, so the SDK's awaits actually
        ///     suspend. (A handler returning Task.FromResult completes synchronously and would
        ///     never expose the bug.)
        /// </summary>
        private sealed class YieldingHandler : HttpMessageHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {
                await Task.Delay(50, cancellationToken).ConfigureAwait(false);
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(new byte[0])
                };
            }
        }
    }
}
