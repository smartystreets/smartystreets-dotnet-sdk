namespace SmartyStreets.USZipCodeApi
{
	using NUnit.Framework;

	[TestFixture]
	public class BatchTests
	{
		[Test]
		public void TestGetsLookupById()
		{
			var batch = new Batch();
			batch.Add(new Lookup
			{
				InputId = "hasInputId"
			});

			Assert.NotNull(batch.Get("hasInputId"));
		}

		[Test]
		public void TestGetsLookupByIndex()
		{
			var batch = new Batch();
			batch.Add(new Lookup());

			Assert.NotNull(batch.Get(0));
		}

		[Test]
		public void TestReturnsCorrectSize()
		{
			var batch = new Batch();
			batch.Add(new Lookup
			{
				InputId = "hasInputId"
			});
			batch.Add(new Lookup());
			batch.Add(new Lookup());

			Assert.AreEqual(3, batch.Size());
		}

		[Test]
		[ExpectedException(typeof(BatchFullException))]
		public void TestAddingALookupBatchIsFullThrowsException()
		{
			var batch = new Batch();
			for (var i = 0; i <= Batch.MaxBatchSize; i++)
				batch.Add(new Lookup());
		}

		[Test]
		public void TestClearMethodClearsBothLookupCollections()
		{
			var batch = new Batch();
			batch.Add(new Lookup
			{
				InputId = "hasInputId"
			});
			batch.Add(new Lookup());
			batch.Add(new Lookup());
			batch.Clear();

			Assert.IsEmpty(batch.AllLookups);
			Assert.IsEmpty(batch.NamedLookups);
		}
	}
}