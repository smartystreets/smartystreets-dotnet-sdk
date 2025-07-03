using System.Net.Http;
using System.Threading.Tasks;

namespace SmartyStreets
{
	public interface IClient<in TLookup>
	{
		Task Send(TLookup lookup);
	}
}