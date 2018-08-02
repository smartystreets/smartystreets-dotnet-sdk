#!/usr/bin/make -f

SOURCE_VERSION := 8.0
SOLUTION_FILE := src/smartystreets-dotnet-sdk.sln
PROJECT_FILE := src/sdk/sdk.csproj
TEST_FILE := src/tests/tests.csproj
CONFIGURATION := Release
WORKSPACE_DIR := workspace

# https://github.com/dotnet/sdk/issues/335
export FrameworkPathOverride=$(dir $(shell which mono))/../lib/mono/4.0-api/

clean:
	@rm -rf "$(WORKSPACE_DIR)"
	@dotnet clean "$(SOLUTION_FILE)"

compile: clean
	@dotnet build "$(SOLUTION_FILE)" --configuration "$(CONFIGURATION)"

test:
	@dotnet test "$(TEST_FILE)"

integrate:
	@dotnet run --project "src/examples/examples.csproj"

package: clean
	@mkdir -p "$(WORKSPACE_DIR)"
	@dotnet pack "$(PROJECT_FILE)" --configuration "$(CONFIGURATION)" \
		--include-source \
		--include-symbols \
		--output "../../$(WORKSPACE_DIR)" \
		/p:CustomVersion="$(shell git describe 2>/dev/null)"

publish: clean version package
	@dotnet nuget push $(WORKSPACE_DIR)/* --source nuget.org -k "$(NUGET_KEY)"
	@git push origin --tags

version:
	$(eval PREFIX := $(SOURCE_VERSION).)
	$(eval CURRENT := $(shell git describe 2>/dev/null))
	$(eval EXPECTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr -1 +))
	$(eval INCREMENTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr 0 +))
	@if [ "$(CURRENT)" != "$(EXPECTED)" ]; then git tag -a "$(INCREMENTED)" -m "" 2>/dev/null || true; fi

##########################################################

container-test:
	 docker-compose run sdk make test
container-compile:
	 docker-compose run sdk make compile
container-package:
	 docker-compose run sdk make package
