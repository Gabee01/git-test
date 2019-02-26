# Build image
FROM microsoft/dotnet:2.2-sdk as builder

MAINTAINER "gacarraro@gmail.com"
WORKDIR /app

COPY ./ ./
#COPY ./tests ./tests

RUN dotnet restore
RUN dotnet build web-app/git-repos-web.csproj -c Release --no-restore

#Test
RUN dotnet test tests/git-repos-test.csproj -c Release --no-restore

# Publish
RUN dotnet publish web-app/git-repos-web.csproj -c Release -o /out --no-restore

#App image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
 
COPY --from=builder /out .
ENTRYPOINT ["dotnet", "git-repos-web.dll"]
