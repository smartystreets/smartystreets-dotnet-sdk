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
			var lookup = new Lookup();

			for (var i = 0; i < Batch.MaxBatchSize; i++)
				batch.Add(lookup);

			Assert.Throws<BatchFullException>(() => batch.Add(new Lookup()));
		}

		[Test]
		public void TestClearMethodClearsBothLookupCollectionsButNotHeaders()
		{
			var batch = new Batch
			{
				IncludeInvalid = true,
				StandardizeOnly = true
			};
			batch.Add(new Lookup());

			batch.Clear();

			Assert.AreEqual(true, batch.IncludeInvalid);
			Assert.AreEqual(true, batch.StandardizeOnly);
			Assert.AreEqual(0, batch.Count);
		}

		[Test]
		public void TestResetMethodResetsHeadersAndLookups()
		{
			var batch = new Batch
			{
				IncludeInvalid = true,
				StandardizeOnly = true
			};
			batch.Add(new Lookup());

			batch.Reset();

			Assert.AreEqual(false, batch.IncludeInvalid);
			Assert.AreEqual(false, batch.StandardizeOnly);
			Assert.AreEqual(0, batch.Count);
		}
	}
}