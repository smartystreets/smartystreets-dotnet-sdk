namespace SmartyStreets.USZipCodeApi
{
	using NUnit.Framework;

	[TestFixture]
	public class BatchTests
	{
		[Test]
		public void TestGetsLookupById()
		{
			var batch = new Batch
			{
				new Lookup
				{
					InputId = "hasInputId"
				}
			};

			Assert.NotNull(batch["hasInputId"]);
		}

		[Test]
		public void TestGetsLookupByIndex()
		{
			var batch = new Batch {new Lookup()};

			Assert.NotNull(batch[0]);
		}

		[Test]
		public void TestReturnsCorrectSize()
		{
			var batch = new Batch
			{
				new Lookup
				{
					InputId = "hasInputId"
				},
				new Lookup(),
				new Lookup()
			};

			Assert.AreEqual(3, batch.Count);
		}

		[Test]
		public void TestAddingALookupBatchIsFullThrowsException()
		{
			var batch = new Batch();
			for (var i = 0; i < Batch.MaxBatchSize; i++)
				batch.Add(new Lookup());

			Assert.Throws<BatchFullException>(() => batch.Add(new Lookup()));
		}

		[Test]
		public void TestClearMethodClearsBothLookupCollections()
		{
			var batch = new Batch
			{
				new Lookup
				{
					InputId = "hasInputId"
				},
				new Lookup(),
				new Lookup()
			};
			batch.Clear();

			Assert.AreEqual(0, batch.Count);
		}
	}
}