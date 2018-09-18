#!/usr/bin/make -f

SOLUTION_FILE := src/$(NAME).sln
PROJECT_FILE  := src/sdk/sdk.csproj
TEST_FILE     := src/tests/tests.csproj
CONFIGURATION := Release
WORKSPACE_DIR := workspace

# https://github.com/dotnet/sdk/issues/335
export FrameworkPathOverride=$(dir $(shell which mono))/../lib/mono/4.0-api/

clean:
	# NOTE: for some crazy reason running make clean after make compile in a container fails
	rm -rf "$(WORKSPACE_DIR)"
	dotnet clean "$(SOLUTION_FILE)"

compile: clean
	dotnet build "$(SOLUTION_FILE)" --configuration "$(CONFIGURATION)"

test:
	dotnet test "$(TEST_FILE)"

integrate:
	dotnet run --project "src/examples/examples.csproj"

package: clean
	dotnet pack "$(PROJECT_FILE)" --configuration "$(CONFIGURATION)" \
		--include-source \
		--include-symbols \
		--output "../../$(WORKSPACE_DIR)" \
		/p:CustomVersion="$(shell tagit -p --dry-run)"

publish: clean package
	dotnet nuget push $(WORKSPACE_DIR)/* --source nuget.org -k "$(NUGET_KEY)"

##########################################################

version:
	tagit -p

dev:
	docker build . --no-cache --rm -t "smartystreets-dotnet-sdk:latest" \
		&& docker-compose run sdk

.PHONY: clean compile test integrate package publish version dev
