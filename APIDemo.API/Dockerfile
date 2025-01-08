FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY . .

WORKDIR /app/APIDemo.API
RUN dotnet restore 
RUN dotnet publish -c release -o out --no-restore --no-self-contained

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

EXPOSE 5004
EXPOSE 8080

WORKDIR /app/APIDemo.API
COPY --from=build /app/APIDemo.API/out ./
ENTRYPOINT ["dotnet", "APIDemo.API.dll"]