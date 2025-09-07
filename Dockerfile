# ============================
# Stage 1: React Build
# ============================
FROM node:20 AS node-build
WORKDIR /src

# Copy React package.json and install deps
COPY BillSplit.Client/package*.json ./BillSplit.Client/
WORKDIR /src/BillSplit.Client
RUN npm install

# Copy the rest of the React source and build
COPY BillSplit.Client/. .
RUN npm run build

# ============================
# Stage 2: .NET API Build & Publish
# ============================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj files for NuGet restore caching
COPY BillSplit.API/BillSplit.API.csproj BillSplit.API/
COPY BillSplit.Infrastructure/BillSplit.Infrastructure.csproj BillSplit.Infrastructure/
COPY BillSplit.Application/BillSplit.Application.csproj BillSplit.Application/
COPY BillSplit.Domain/BillSplit.Domain.csproj BillSplit.Domain/

# Restore NuGet packages
RUN dotnet restore BillSplit.API/BillSplit.API.csproj

# Copy the rest of the source
COPY . .

# Copy React build output from Stage 1 into API's wwwroot
COPY --from=node-build /src/BillSplit.Client/dist ./BillSplit.API/wwwroot

# Publish API
WORKDIR /src/BillSplit.API
RUN dotnet publish "BillSplit.API.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false

# ============================
# Stage 3: Final Runtime Image
# ============================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Create a non-root user
RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
USER appuser

# Expose API & HTTPS ports
EXPOSE 8080
EXPOSE 8081

# Copy published output
COPY --from=publish /app/publish .

# Run the application
ENTRYPOINT ["dotnet", "BillSplit.API.dll"]
