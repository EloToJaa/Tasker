# Tasker

## Description

This project implements CLEAN architecture and DDD in a simple application.

## Migration

To run a database migration, run the following command:

```pwsh
dotnet ef migrations add -p .\src\Infrastructure\Infrastructure.csproj -s .\src\Api\Api.csproj MIGRATION_NAME
dotnet ef database update -p .\src\Infrastructure\Infrastructure.csproj -s .\src\Api\Api.csproj
```

## Docker

`docker-compose.yml`

## Create expo app from template

```bash
bunx create-expo-app -e with-router-tailwind
```