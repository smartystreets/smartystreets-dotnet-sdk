using System;
using System.Threading.Tasks;

namespace SmartyStreets
{
	public interface IClient<in TLookup> : IDisposable
	{
		void Send(TLookup lookup);
		Task SendAsync(TLookup lookup);
	}
}