namespace SmartyStreets
{
	using System.IO;

	public interface ISerializer
	{
		byte[] Serialize(object graph);

		T Deserialize<T>(Stream source) where T : class;
	}
}