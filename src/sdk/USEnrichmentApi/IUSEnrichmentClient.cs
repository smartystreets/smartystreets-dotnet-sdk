namespace SmartyStreets.USEnrichmentApi
{
    // marker interface for easy dependency injection and unit test mocking
    public interface IUSEnrichmentClient
    {
        sendPropertyPrincipalLookup(string smartyKey);
        sendPropertyFinancialLookup(string smartyKey);
    }
}