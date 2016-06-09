namespace SmartyStreets
{
	public interface ISender
	{
		Response Send(Request request);
	}
}