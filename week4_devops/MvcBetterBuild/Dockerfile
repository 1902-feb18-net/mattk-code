# dotnet new mvc -o ../MvcBetterBuild

# multi-stage build - FROM command can name a stage.

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /app

# take advantage of docker layer caching...
# these two layers will be cached so long as the csproj file(s) does not change.
COPY ./*.csproj ./
RUN dotnet restore

# if i just change a .cs file, then i can use that cache and the next line will
# be the first one to actually run.

COPY . ./

# build and publish to /app/out
RUN dotnet publish --no-restore -c Release -o out

# docker allows us to use some layers just temporarily
# and then copy certain files out of them onto a new base image.
# this means the resulting image will be smaller.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime

WORKDIR /app

COPY --from=build /app/out ./

# ENV ASPNETCORE_URLS=http://*:5050;

ENTRYPOINT [ "dotnet", "MvcBetterBuild.dll" ]

# best of both worlds from multi-statge build:
# repeatable build environment, plus small image size





