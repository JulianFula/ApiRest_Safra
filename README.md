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

1.Para realizar un nuevo registro debe usarse el metodo CreateUser, en el se pedira el Schema UserRequest.

2.Para realizar el registro en la aplicacion puede hacerlo con el usuario anteriormente creado o usar los siguientes datos de prueba:
    UsrEmail="user1@example.com", UsrPass="Password1"
    UsrEmail="user2@example.com", UsrPass="Password2"
    
3.Los metodos correspondientes al CRUD de Users piden el JWT Token que se entrega al registrarse en la aplicacion

4.Para probar los EndPoints correspondientes a la descarga y carga de archivos CVS, recomiendo primero usar el metodo ExportClientsToCsv para asi obtener el archivo con los headers necesarios para la carga y guardado en el metodo UploadClientsCSV.

