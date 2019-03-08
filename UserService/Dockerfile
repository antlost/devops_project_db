# Container used to build
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY UserService/*.csproj ./UserService/
RUN dotnet restore

# copy source code and build
COPY UserService/. ./UserService/
WORKDIR /app/UserService
RUN dotnet publish -c Release -o out

# Published runtime container
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/UserService/out ./
EXPOSE 2222/tcp
ENTRYPOINT ["dotnet", "UserService.dll"]