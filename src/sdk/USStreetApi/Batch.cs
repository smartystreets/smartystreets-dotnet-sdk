namespace SmartyStreets.USStreetApi
{
	public class Batch : Batch<Lookup>
	{
		public const int MaxBatchSize = 100;

		public Batch() : base(MaxBatchSize)
		{
		}
	}
}