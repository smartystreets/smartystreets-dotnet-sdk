namespace SmartyStreets
{
	using System.IO;
	using System.Runtime.Serialization.Json;

	public class NativeSerializer : ISerializer
	{
		public byte[] Serialize(object graph)
		{
			if (graph == null)
				return null;

			var serializer = new DataContractJsonSerializer(graph.GetType());
			using (var stream = new MemoryStream())
			{
				serializer.WriteObject(stream, graph);
				return stream.ToArray();
			}
		}

		public T Deserialize<T>(Stream source) where T : class
		{
			if (source == null)
				return null;

			var serializer = new DataContractJsonSerializer(typeof(T));
			return (T)serializer.ReadObject(source);
		}
	}
}