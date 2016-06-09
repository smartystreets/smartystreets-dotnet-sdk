namespace SmartyStreets
{
	public interface ICredentials
	{
		void Sign(Request request);
	}
}