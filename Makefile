#!/usr/bin/make -f

SOURCE_VERSION := 8.0
SOLUTION_FILE := src/smartystreets-dotnet-sdk.sln
PROJECT_FILE := src/sdk/sdk.csproj
CONFIGURATION := Release
WORKSPACE_DIR := workspace

clean:
	@rm -rf "$(WORKSPACE_DIR)"
	@dotnet clean "$(SOLUTION_FILE)"

compile: clean
	@dotnet build "$(SOLUTION_FILE)" --configuration "$(CONFIGURATION)"

test:

package:
	@sed -i -r "s/0\.0\.0/$(shell git describe)/g" src/sdk/sdk.csproj

	@mkdir -p "$(WORKSPACE_DIR)"
	@dotnet pack "$(PROJECT_FILE)" --configuration "$(CONFIGURATION)" \
		--include-source \
		--include-symbols \
		--output "../../$(WORKSPACE_DIR)"

	@git checkout "src/sdk/sdk.csproj"

publish: clean version package
	@dotnet nuget push $(WORKSPACE_DIR)/* --source nuget.org
	@git push origin --tags

version:
	$(eval PREFIX := $(SOURCE_VERSION).)
	$(eval CURRENT := $(shell git describe 2>/dev/null))
	$(eval EXPECTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr -1 +))
	$(eval INCREMENTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr 0 +))
	@if [ "$(CURRENT)" != "$(EXPECTED)" ]; then git tag -a "$(INCREMENTED)" -m "" 2>/dev/null || true; fi
