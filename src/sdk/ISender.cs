namespace SmartyStreets
{
    using System.Threading.Tasks;

    public interface ISender
	{
		Response Send(Request request);
        Task<Response> SendAsync(Request request);
    }
}