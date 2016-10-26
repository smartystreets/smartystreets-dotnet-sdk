using System.Threading.Tasks;

namespace SmartyStreets
{
	public interface ISender
	{
		Response Send(Request request);
        Task<Response> SendAsync(Request request);
    }
}