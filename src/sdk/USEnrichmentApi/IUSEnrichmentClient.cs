namespace SmartyStreets.USEnrichmentApi
{
    // marker interface for easy dependency injection and unit test mocking
    public interface IUSEnrichmentClient
    {
        SmartyStreets.USEnrichmentApi.Property.Principal.Result[] sendPropertyPrincipalLookup(string smartyKey);
        byte[] sendUniversalLookup(Lookup lookup);
    }
}