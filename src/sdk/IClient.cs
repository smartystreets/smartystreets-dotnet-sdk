namespace SmartyStreets
{
	public interface IClient<in TLookup>
	{
		void Send(TLookup lookup);
	}
}