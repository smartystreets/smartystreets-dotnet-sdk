using System;
using System.Threading.Tasks;

namespace SmartyStreets
{
	public interface ISender : IDisposable
	{
		Task<Response> Send(Request request);
		void EnableLogging();
	}
}