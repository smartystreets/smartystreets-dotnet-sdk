#!/usr/bin/make -f

SOLUTION_FILE 	  := src/smartystreets-dotnet-sdk.sln
PROJECT_FILE  	  := src/sdk/sdk.csproj
TEST_FILE     	  := src/tests/tests.csproj
EXAMPLES_PROJECT  := src/examples/examples.csproj
CONFIGURATION 	  := Release
WORKSPACE_DIR 	  := workspace

clean:
	rm -rf "$(WORKSPACE_DIR)"
	dotnet clean "$(SOLUTION_FILE)"

compile: clean
	dotnet build "$(SOLUTION_FILE)" --configuration "$(CONFIGURATION)"

test:
	dotnet test "$(TEST_FILE)"

integrate:
	dotnet run --project "src/integration/integration.csproj"

package: clean
	dotnet pack $(PROJECT_FILE) --configuration $(CONFIGURATION) \
 		--include-source \
 		--include-symbols \
 		 --output ../../$(WORKSPACE_DIR) \
 		  /p:CustomVersion=${VERSION}

publish: clean package
	dotnet nuget push ../../$(WORKSPACE_DIR)/* --source nuget.org -k "${NUGET_KEY}" --skip-duplicate

international_autocomplete_api:
	dotnet run --project $(EXAMPLES_PROJECT) -- international_autocomplete

international_street_api:
	dotnet run --project $(EXAMPLES_PROJECT) -- international_street

international_postal_code_api:
	dotnet run --project $(EXAMPLES_PROJECT) -- international_postal_code

us_autocomplete_pro_api:
	dotnet run --project $(EXAMPLES_PROJECT) -- us_autocomplete_pro

us_enrichment_api:
	dotnet run --project $(EXAMPLES_PROJECT) -- us_enrichment

us_extract_api:
	dotnet run --project $(EXAMPLES_PROJECT) -- us_extract

us_reverse_geo_api:
	dotnet run --project $(EXAMPLES_PROJECT) -- us_reverse_geo

us_street_api:
	dotnet run --project $(EXAMPLES_PROJECT) -- us_street_single && \
	dotnet run --project $(EXAMPLES_PROJECT) -- us_street_multiple && \
	dotnet run --project $(EXAMPLES_PROJECT) -- us_street_component_analysis
	
us_zipcode_api:
	dotnet run --project $(EXAMPLES_PROJECT) -- us_zipcode_single && \
	dotnet run --project $(EXAMPLES_PROJECT) -- us_zipcode_multiple

# Run all examples
examples: international_autocomplete_api international_street_api us_autocomplete_pro_api us_enrichment_api us_extract_api us_reverse_geo_api us_street_api us_zipcode_api

##########################################################
release:
	make publish

.PHONY: clean compile test integrate package publish version release examples international_autocomplete_api international_street_api us_autocomplete_pro_api us_enrichment_api us_extract_api us_reverse_geo_api us_street_api us_zipcode_api

