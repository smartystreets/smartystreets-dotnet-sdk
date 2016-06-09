using NUnit.Framework;

namespace SmartyStreets.USStreetApi
{
	[TestFixture]
	public class BatchTests
	{
		[Test]
		public void TestGetsLookupByInputId()
		{
			var batch = new Batch();
			var lookup = new Lookup();
			lookup.InputId = "hasInputId";

			batch.Add(lookup);

			Assert.AreEqual(lookup, batch.Get("hasInputId"));
		}

		[Test]
		public void TestGetsLookupByIndex()
		{
			var batch = new Batch();
			var lookup = new Lookup();

			batch.Add(lookup);

			Assert.AreEqual(lookup, batch.Get(0));
		}

		[Test]
		public void TestReturnsCorrectSize()
		{
			var batch = new Batch();
			var lookup = new Lookup();

			batch.Add(lookup);
			batch.Add(lookup);
			batch.Add(lookup);

			Assert.AreEqual(3, batch.Size());
		}

		[Test]
		[ExpectedException(typeof(BatchFullException))]
		public void TestAddingALookupWhenBatchIsFullThrowsException()
		{
			var batch = new Batch();
			var lookup = new Lookup();

			for (int i = 0; i <= Batch.MAX_BATCH_SIZE; i++)
			{
				batch.Add(lookup);
			}
		}

		[Test]
		public void TestClearMethodClearsBothLookupCollectionsButNotHeaders()
		{
			var batch = new Batch();
			batch.IncludeInvalid = true;
			batch.StandardizeOnly = true;
			batch.Add(new Lookup());

			batch.Clear();

			Assert.AreEqual(true, batch.IncludeInvalid);
			Assert.AreEqual(true, batch.StandardizeOnly);
			Assert.AreEqual(0, batch.AllLookups.Count);
			Assert.AreEqual(0, batch.NamedLookups.Count);
		}

		[Test]
		public void TestResetMethodResetsHeadersAndLookups()
		{
			var batch = new Batch();
			batch.IncludeInvalid = true;
			batch.StandardizeOnly = true;
			batch.Add(new Lookup());

			batch.Reset();

			Assert.AreEqual(false, batch.IncludeInvalid);
			Assert.AreEqual(false, batch.StandardizeOnly);
			Assert.AreEqual(0, batch.AllLookups.Count);
			Assert.AreEqual(0, batch.NamedLookups.Count);
		}

	}
}

