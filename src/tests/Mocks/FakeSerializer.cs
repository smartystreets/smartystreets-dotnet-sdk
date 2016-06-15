namespace SmartyStreets
{
	using System.IO;

	public class FakeSerializer : ISerializer
	{
		private readonly byte[] bytes;

		public FakeSerializer(byte[] bytes)
		{
			this.bytes = bytes;
		}

		public byte[] Serialize(object graph)
		{
			return this.bytes;
		}

		public T Deserialize<T>(Stream source) where T : class
		{
			return null;
		}
	}
}