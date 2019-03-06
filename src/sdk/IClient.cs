using System.Threading.Tasks;

namespace SmartyStreets
{
	public interface IClient<in TLookup>
	{
		Task SendAsync(TLookup lookup);
	}
}