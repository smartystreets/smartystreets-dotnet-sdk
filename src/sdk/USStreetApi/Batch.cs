namespace SmartyStreets.USStreetApi
{
	public class Batch : Batch<Lookup>
	{
		public const int MaxBatchSize = 100;
		public bool StandardizeOnly { get; set; }
		public bool IncludeInvalid { get; set; }

		public Batch() : base(MaxBatchSize)
		{
			this.StandardizeOnly = false;
			this.IncludeInvalid = false;
		}

		public void Reset()
		{
			this.Clear();
			this.StandardizeOnly = false;
			this.IncludeInvalid = false;
		}
	}
}