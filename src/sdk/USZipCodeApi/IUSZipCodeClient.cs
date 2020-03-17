namespace SmartyStreets.USZipCodeApi
{
    // marker interface for easy dependency injection and unit test mocking
    public interface IUSZipCodeClient : IClient<Lookup>
    {
        void Send(Batch batch);
    }
}