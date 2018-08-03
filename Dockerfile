FROM microsoft/dotnet:2.1-sdk-alpine

ADD . /code
WORKDIR /code

RUN echo '@edge http://dl-cdn.alpinelinux.org/alpine/edge/main' >> /etc/apk/repositories \
  && echo '@community http://dl-cdn.alpinelinux.org/alpine/edge/community' >> /etc/apk/repositories \
  && echo '@testing http://dl-cdn.alpinelinux.org/alpine/edge/testing' >> /etc/apk/repositories \
  && apk add -U make git mono-dev@testing
