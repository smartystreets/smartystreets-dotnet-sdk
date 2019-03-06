using System.Threading.Tasks;

namespace SmartyStreets
{
	public interface ISender
	{
		Task<Response> SendAsync(Request request);
	}
}