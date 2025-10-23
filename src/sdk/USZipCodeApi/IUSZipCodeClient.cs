namespace SmartyStreets.USZipCodeApi
{
    using System.Threading.Tasks;

    // marker interface for easy dependency injection and unit test mocking
    public interface IUSZipCodeClient : IClient<Lookup>
    {
        void Send(Batch batch);
        Task SendAsync(Batch batch);
    }
}