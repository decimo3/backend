# Use the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
# Set the working directory
WORKDIR /App
# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Copy everything else and build
RUN dotnet publish -c Release -o out
# Install Entity Framework tools
RUN dotnet tool restore
# Ensure the tool binaries are available in the PATH
ENV PATH="$PATH:/root/.dotnet/tools"
# Apply migrations and update the database
RUN dotnet ef database update
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
# Set the working directory
WORKDIR /App
# Copy everything from build-env
COPY --from=build-env /App/out .
# Run the application
ENTRYPOINT ["dotnet", "backend.dll"]
