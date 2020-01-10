namespace SmartyStreets.USStreetApi
{
    // marker interface for easy dependency injection and unit test mocking
    public interface IUSStreetClient : IClient<Lookup>
    {
        void Send(Batch batch);
    }
}