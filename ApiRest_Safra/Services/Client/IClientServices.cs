using ApiRest_Safra.Models.Client;
using ApiRest_Safra.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_Safra.Services.Client;

public interface IClientServices
{
    //Se crea en el servicio el metodo para registrar usuario
    Task<ClientResponse> CreateUser(UserRequest UserRequest);
    //Se crea en el servicio el metodo para consultar usuarios
    Task<ClientResponse> GetAllClients();
    //Se crea en el servicio el metodo para editar Usuarios
    Task<ClientResponse> UpdateUser(UserRequest UserRequest);
    //Se crea en el servicio el metodo para eliminar usuario
    Task<ClientResponse> DeleteUser(UserRequest UserRequest);
    //Se crea en el servicio el metodo para exportar a CVS
    Task<MemoryStream> ExportClientsToCsv();
    //Se crea en el servicio el metodo para exportar a CVS
    Task<ClientResponse> UploadClientsCSV(IFormFile file);

}
