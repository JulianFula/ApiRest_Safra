# Usar la imagen base de .NET 8 para el SDK (compilación)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar los archivos de proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y compilar
COPY . ./
RUN dotnet publish -c Release -o out

# Usar la imagen base de .NET 8 para runtime (ejecución)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Exponer el puerto en el que la aplicación escucha (opcional)
EXPOSE 80

# Comando de inicio
ENTRYPOINT ["dotnet", "ApiRest_Safra.dll"]