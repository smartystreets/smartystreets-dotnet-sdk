#!/usr/bin/make -f

SOLUTION_FILE := src/smartystreets-dotnet-sdk.sln
PROJECT_FILE  := src/sdk/sdk.csproj
TEST_FILE     := src/tests/tests.csproj
CONFIGURATION := Release
WORKSPACE_DIR := workspace

# https://github.com/dotnet/sdk/issues/335
export FrameworkPathOverride=$(dir $(shell which mono))/../lib/mono/4.0-api/

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

##########################################################
release:
	make publish

.PHONY: clean compile test integrate package publish version release
