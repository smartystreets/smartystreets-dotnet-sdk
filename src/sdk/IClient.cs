using System;
using System.Threading.Tasks;

namespace SmartyStreets
{
	public interface IClient<in TLookup> : IDisposable
	{
		Task Send(TLookup lookup);
	}
}