namespace SmartyStreets
{
	using System;
	using System.IO;

	public class FakeDeserializer : ISerializer
	{
		private readonly Object deserialized;
		public byte[] Payload { get; private set; }

		public FakeDeserializer(Object deserialized)
		{
			this.deserialized = deserialized;
		}

		public byte[] Serialize(object graph)
		{
			return new byte[0];
		}

		public T Deserialize<T>(Stream source) where T : class
		{
			this.Payload = StreamToByteArray(source);
			return (T)this.deserialized;
		}

		private static byte[] StreamToByteArray(Stream source)
		{
			using (var memoryStream = new MemoryStream())
			{
				source.CopyTo(memoryStream);
				return memoryStream.ToArray();
			}
		}
	}
}
