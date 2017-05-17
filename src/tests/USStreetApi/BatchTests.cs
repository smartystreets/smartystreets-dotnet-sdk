namespace SmartyStreets.USStreetApi
{
	using NUnit.Framework;

	[TestFixture]
	public class BatchTests
	{
		[Test]
		public void TestGetsLookupByInputId()
		{
			var batch = new Batch();
			var lookup = new Lookup
			{
				InputId = "hasInputId"
			};

			batch.Add(lookup);

			Assert.AreEqual(lookup, batch["hasInputId"]);
		}

		[Test]
		public void TestGetsLookupByIndex()
		{
			var batch = new Batch();
			var lookup = new Lookup();

			batch.Add(lookup);

			Assert.AreEqual(lookup, batch[0]);
		}

		[Test]
		public void TestReturnsCorrectSize()
		{
			var batch = new Batch();
			var lookup = new Lookup();

			batch.Add(lookup);
			batch.Add(lookup);
			batch.Add(lookup);

			Assert.AreEqual(3, batch.Count);
		}

		[Test]
		public void TestAddingALookupWhenBatchIsFullThrowsException()
		{
			var batch = new Batch();

			for (var i = 0; i < Batch.MaxBatchSize; i++)
				batch.Add(new Lookup());

			Assert.Throws<BatchFullException>(() => batch.Add(new Lookup()));
		}

		[Test]
		public void TestClearMethodClearsBothLookupCollections()
		{
			var batch = new Batch {new Lookup(), new Lookup()};

			batch.Clear();

			Assert.AreEqual(0, batch.Count);
		}
	}
}