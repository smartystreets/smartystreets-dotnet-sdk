#!/usr/bin/make -f

SOLUTION_FILE := src/smartystreets-dotnet-sdk.sln
PROJECT_FILE := src/sdk/sdk.csproj
TEST_FILE := src/tests/tests.csproj
CONFIGURATION := Release
WORKSPACE_DIR := workspace

# https://github.com/dotnet/sdk/issues/335
export FrameworkPathOverride=$(dir $(shell which mono))/../lib/mono/4.0-api/

clean:
	# NOTE: for some crazy reason running make clean after make compile in a container fails
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
		/p:CustomVersion="$(shell git describe)"

publish: clean package
	@dotnet nuget push $(WORKSPACE_DIR)/* --source nuget.org -k "$(NUGET_KEY)"

version:
	@tagit -p

##########################################################

container-compile:
	docker-compose run sdk make compile
container-test:
	docker-compose run sdk make test
container-integrate:
	docker-compose run sdk make integrate
container-package:
	docker-compose run sdk make package
container-publish: version
	docker-compose run sdk make publish
	git push origin --tags
