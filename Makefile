#!/usr/bin/make -f

SOURCE_VERSION := 1.0

build:
	xbuild /p:Configuration=Release /t:Rebuild src/smartystreets-csharp-sdk.sln
	git checkout src/VersionAssemblyInfo.cs

test:

package: build
	@rm -f src/sdk/*.nupkg
	@nuget pack src/sdk/SDK.nuspec -o src/sdk
	git checkout src/sdk/SDK.nuspec

publish: version tag package
	@nuget push src/sdk/smartystreets-csharp-sdk.*.nupkg -source https://www.nuget.org

tag:
	@sed -i -r "s/0\.0\.0/$(shell git describe)/g" src/sdk/SDK.nuspec
	@sed -i -r "s/0\.0\.0/$(shell git describe)/g" src/VersionAssemblyInfo.cs

version:
	$(eval PREFIX := $(SOURCE_VERSION).)
	$(eval CURRENT := $(shell git describe 2>/dev/null))
	$(eval EXPECTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr -1 +))
	$(eval INCREMENTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr 0 +))
	@if [ "$(CURRENT)" != "$(EXPECTED)" ]; then git tag -a "$(INCREMENTED)" -m "" 2>/dev/null || true; fi
