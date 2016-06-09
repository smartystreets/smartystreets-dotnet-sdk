using NUnit.Framework;

namespace SmartyStreets.USZipCodeApi
{
	[TestFixture]
	public class BatchTests
	{
		[Test]
		public void TestGetsLookupById()
		{
			var lookup = new Lookup();
			lookup.InputId = "hasInputId";
			var batch = new Batch();

			batch.Add(lookup);

			Assert.NotNull(batch.Get("hasInputId"));
		}

		[Test]
		public void TestGetsLookupByIndex()
		{
			var lookup = new Lookup();
			var batch = new Batch();

			batch.Add(lookup);
		
			Assert.NotNull(batch.Get(0));
		}

		[Test]
		public void TestReturnsCorrectSize()
		{
			var batch = new Batch();
			var lookupWithId = new Lookup();
			lookupWithId.InputId = "hasInputId";

			batch.Add(lookupWithId);
			batch.Add(new Lookup());
			batch.Add(new Lookup());

			Assert.AreEqual(3, batch.Size());
		}

		[Test]
		[ExpectedException(typeof(BatchFullException))]
		public void TestAddingALookupBatchIsFullThrowsException()
		{
			var batch = new Batch();

			for (int i = 0; i <= Batch.MAX_BATCH_SIZE; i++)
			{
				batch.Add(new Lookup());
			}
		}

		[Test]
		public void TestClearMethodClearsBothLookupCollections()
		{
			var batch = new Batch();
			var lookupWithId = new Lookup();
			lookupWithId.InputId = "hasInputId";

			batch.Add(lookupWithId);
			batch.Add(new Lookup());
			batch.Add(new Lookup());
			batch.Clear();

			Assert.IsEmpty(batch.AllLookups);
			Assert.IsEmpty(batch.NamedLookups);
		}
	}
}

