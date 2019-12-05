
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "api.dll"]

#RUN
#docker build -t  webapi . && docker run -p 5000:80 webapi




#test locally
#docker build -t ct-webapi .
#docker run -d -p 8080:80 --name webapi-ct cd-webapi

#docker image ls
