using System.Threading.Tasks;

namespace SmartyStreets
{
	public interface ISender
	{
		Task<Response> Send(Request request);
	}
}