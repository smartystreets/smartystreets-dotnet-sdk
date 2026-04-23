# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build Commands

```bash
make compile        # Clean and build full solution (Release config)
make test           # Run unit tests
make integrate      # Run integration tests
dotnet test src/tests/tests.csproj --filter "FullyQualifiedName~ClassName"  # Run specific test class
dotnet test src/tests/tests.csproj --filter "FullyQualifiedName~ClassName.MethodName"  # Run single test
```

Running examples (requires `SMARTY_AUTH_ID` and `SMARTY_AUTH_TOKEN` environment variables):
```bash
make examples               # Run all examples
make us_street_api          # US Street API examples
make international_street_api  # International Street API example
```

## Architecture Overview

This SDK uses a **decorator/pipeline pattern** for HTTP request handling. The `ClientBuilder` constructs a chain of `ISender` implementations that wrap each other:

```
Application → Client → Sender Chain → Network
                         ↓
              CustomQuerySender (query params)
              LicenseSender (license tracking)
              RetrySender (exponential backoff)
              URLPrefixSender (base URL)
              SigningSender (credentials)
              CustomHeaderSender (custom headers)
              StatusCodeSender (error handling)
              NativeSender (HttpClient)
```

The order of sender wrapping matters - it's constructed in `ClientBuilder.BuildSender()`.

## Project Structure

- **src/sdk/** - Main library (multi-targets: net8.0, netstandard2.0)
- **src/tests/** - NUnit tests with mock implementations in `Mocks/`
- **src/examples/** - Runnable C# examples
- **src/integration/** - Integration tests

Each API has its own namespace under `SmartyStreets.*Api/` with consistent structure:
- `Client.cs` - API client with `Send()` and `SendAsync()` methods
- `Lookup.cs` - Request parameters
- `Candidate.cs` or `Result.cs` - Response data
- `Batch.cs` - Batch request container (where applicable)

## Key Patterns

**Async-first design**: Sync methods wrap async internally via `SendAsync().GetAwaiter().GetResult()`

**Batch handling**: Single lookup uses query string (GET); multiple lookups use JSON payload (POST). Batch max size is 100 items.

**Testing**: Uses mock senders (`RequestCapturingSender`, `MockSender`, `FakeSerializer`) to test without network calls.

**Serialization**: Uses `DataContractJsonSerializer` with no external dependencies. All serializable types must have `[DataContract]` and `[DataMember(Name = "...")]` attributes.

**Credentials**: Three implementations of `ICredentials`:
- `StaticCredentials` - auth-id/auth-token as query params (most common)
- `SharedCredentials` - key + Referer header (browser/client-side)
- `BasicAuthCredentials` - HTTP Basic auth header

**Custom parameters**: All Lookup classes support `AddCustomParameter()` for forward-compatible extensibility without code changes.

**Interface markers**: Each API defines an interface (e.g., `IUSStreetClient` extends `IClient<Lookup>`) for dependency injection.

**URL construction**: `Request.GetUrl()` combines urlPrefix (set by `URLPrefixSender`) + urlComponents (set by API clients) + query parameters. Setting `Request.Payload` automatically switches method to POST.

## US Enrichment API Differences

The Enrichment API diverges from the standard pattern:
- Uses abstract `Lookup` base class with per-dataset subclasses (PropertyPrincipal, GeoReference, etc.)
- Dynamic URL paths: `/search/{dataset}/{subset}` or `/{smartyKey}/{dataset}/{subset}`
- Supports ETag-based conditional requests (304 Not Modified) via a non-standard `Etag` request header (the us-enrichment-api server reads and writes a header literally named `Etag`, not RFC 7232's `If-None-Match`)
- Universal dataset returns raw `byte[]` instead of typed results
- Business Detail (`Business.Detail.Lookup`) is a **standalone** class that does NOT inherit from the abstract `Lookup`. Its URL is `/business/{url-encoded-businessId}` (a third URL shape, distinct from the smartyKey and `/search/` shapes). Send it via `SendBusinessDetailLookup(...)`, which has its own request-building path on the Client and returns a single `Business.Detail.Result` (the endpoint always returns 0 or 1; >1 throws `SmartyException`).

## Adding a New API

1. Create namespace folder: `src/sdk/{ApiName}Api/`
2. Add Client, Lookup, and result classes following existing patterns
3. Add `Build{ApiName}ApiClient()` method to `ClientBuilder.cs`
4. Add URL constant in `ClientBuilder.cs`
5. Add tests in `src/tests/{ApiName}Api/`
6. Add example in `src/examples/`
