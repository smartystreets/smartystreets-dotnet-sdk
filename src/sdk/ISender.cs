using System;
using System.Threading.Tasks;

namespace SmartyStreets
{
	public interface ISender : IDisposable
	{
		Response Send(Request request);
		Task<Response> SendAsync(Request request);
		void EnableLogging();
	}
}