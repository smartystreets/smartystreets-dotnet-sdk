#!/usr/bin/make -f

SOURCE_VERSION := 1.0

build: tag
	xbuild /p:Configuration=Release src/smartystreets-csharp-sdk.sln
	git checkout src/VersionAssemblyInfo.cs

test:

package: build
	@nuget pack src/sdk/SDK.nuspec
	git checkout src/sdk/SDK.nuspec

publish: version package
	#@nuget push ...

tag:
	@sed -i "" "s/0\.0\.0/$(shell git describe)/" src/sdk/SDK.nuspec
	@sed -i "" "s/0\.0\.0/$(shell git describe)/" src/VersionAssemblyInfo.cs

version:
	$(eval PREFIX := $(SOURCE_VERSION).)
	$(eval CURRENT := $(shell git describe 2>/dev/null))
	$(eval EXPECTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr -1 +))
	$(eval INCREMENTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr 0 +))
	@if [ "$(CURRENT)" != "$(EXPECTED)" ]; then git tag -a "$(INCREMENTED)" -m "" 2>/dev/null || true; fi
