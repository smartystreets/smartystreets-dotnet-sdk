#!/usr/bin/make -f

SOURCE_VERSION := 8.0
SOLUTION_FILE := src/smartystreets-dotnet-sdk.sln
PROJECT_FILE := src/sdk/sdk.csproj
TEST_FILE := src/tests/tests.csproj
CONFIGURATION := Release
WORKSPACE_DIR := workspace

clean:
	@rm -rf "$(WORKSPACE_DIR)"
	@dotnet clean "$(SOLUTION_FILE)"

compile: clean
	@dotnet build "$(SOLUTION_FILE)" --configuration "$(CONFIGURATION)"

test:
	@dotnet test "$(TEST_FILE)"

package: clean
	@mkdir -p "$(WORKSPACE_DIR)"
	@dotnet pack "$(PROJECT_FILE)" --configuration "$(CONFIGURATION)" \
		--include-source \
		--include-symbols \
		--output "../../$(WORKSPACE_DIR)" \
		/p:CustomVersion="$(SOURCE_VERSION).$(shell git tag -l "$(SOURCE_VERSION).*" | wc -l | xargs expr 0 +)"

publish: clean version package
	@dotnet nuget push $(WORKSPACE_DIR)/* --source nuget.org
	@git push origin --tags

version:
	$(eval PREFIX := $(SOURCE_VERSION).)
	$(eval CURRENT := $(shell git describe 2>/dev/null))
	$(eval EXPECTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr -1 +))
	$(eval INCREMENTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr 0 +))
	@if [ "$(CURRENT)" != "$(EXPECTED)" ]; then git tag -a "$(INCREMENTED)" -m "" 2>/dev/null || true; fi
