FROM microsoft/dotnet:2.1-sdk

ADD . /code
WORKDIR /code

RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF && \
	echo "deb http://download.mono-project.com/repo/debian stable-stretch main" > /etc/apt/sources.list.d/mono-official-stable.list && \
	apt-get update && \
	apt-get install -y mono-devel make git-core
