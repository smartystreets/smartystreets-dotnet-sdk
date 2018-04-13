#!/usr/bin/make -f

SOURCE_VERSION := 8.0

clean:

build: clean

test:

package: clean build

publish: clean version tag package

tag:
	@sed -i -r "s/0\.0\.0/$(shell git describe)/g" src/sdk/SDK.nuspec
	@sed -i -r "s/0\.0\.0/$(shell git describe)/g" src/VersionAssemblyInfo.cs

version:
	$(eval PREFIX := $(SOURCE_VERSION).)
	$(eval CURRENT := $(shell git describe 2>/dev/null))
	$(eval EXPECTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr -1 +))
	$(eval INCREMENTED := $(PREFIX)$(shell git tag -l "$(PREFIX)*" | wc -l | xargs expr 0 +))
	@if [ "$(CURRENT)" != "$(EXPECTED)" ]; then git tag -a "$(INCREMENTED)" -m "" 2>/dev/null || true; fi
