namespace SmartyStreets.USStreetApi
{
    using System.Threading.Tasks;
    // marker interface for easy dependency injection and unit test mocking
    public interface IUSStreetClient : IClient<Lookup>
    {
        Task Send(Batch batch);
    }
}