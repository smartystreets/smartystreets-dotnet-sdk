using System;
using System.IO;

namespace SmartyStreets
{
	public interface ISerializer
	{
		byte[] Serialize(object graph);

		T Deserialize<T>(Stream source);
	}
}