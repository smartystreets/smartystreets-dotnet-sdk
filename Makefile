#!/usr/bin/make -f

SOURCE_VERSION := 2.0

clean:
	@git checkout src/VersionAssemblyInfo.cs
	@git checkout src/sdk/SDK.nuspec

build: clean
	@xbuild /p:Configuration=Release /t:Rebuild src/smartystreets-csharp-sdk.sln
	@git checkout src/VersionAssemblyInfo.cs

test:

package: clean build
	@rm -f src/sdk/*.nupkg
	@nuget pack src/sdk/SDK.nuspec -o src/sdk
	@git checkout src/sdk/SDK.nuspec

publish: clean version tag package
	@nuget push src/sdk/smartystreets-csharp-sdk.*.nupkg "${NUGET_KEY}" -source https://www.nuget.org
	@git push origin --tags

tag:
	@sed -i -r "s/0\.0\.0/$(shell git describe)/g" src/sdk/SDK.nuspec
	@sed -i -r "s/0\.0\.0/$(shell git describe)/g" src/VersionAssemblyInfo.cs

version:
	$(eval PREFIX := $(SOURCE_VERSION).)
	$(eval CURRENT := $(shell git describe 2>/dev/null))
	$(eval EXPECTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr -1 +))
	$(eval INCREMENTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr 0 +))
	@if [ "$(CURRENT)" != "$(EXPECTED)" ]; then git tag -a "$(INCREMENTED)" -m "" 2>/dev/null || true; fi
