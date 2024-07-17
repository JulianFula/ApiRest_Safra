# ApiRest_Safra

## Descripción
Esta es una API RESTful creada con .NET.

## Requisitos
- [.NET SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)

## Ejecución

1. Clonar el repositorio:
    ```bash
    git clone https://github.com/JulianFula/ApiRest_Safra.git
    cd ApiRest_Safra
    ```

2. Construir y ejecutar la API con Docker:
    ```bash
    docker-compose up --build
    ```

3. La API estará disponible en `http://localhost:8080`.

## Pruebas

Puedes probar la API utilizando [Postman](https://www.postman.com/) o [curl](https://curl.se/).

### Ejemplo de solicitud GET
```bash
curl -X GET http://localhost:8080/api/GetUsers
