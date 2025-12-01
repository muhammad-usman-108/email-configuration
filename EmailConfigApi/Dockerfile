# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Use the ASP.NET runtime image for production
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port your app listens on
EXPOSE 5182

# Set environment variable for Development if needed (Swagger, logs)
ENV DOTNET_ENVIRONMENT=Development

# Run the app
ENTRYPOINT ["dotnet", "EmailConfigApi.dll"]
