using ApiRest_Safra.Models.DTO;
using ApiRest_Safra.Models.User;

namespace ApiRest_Safra.Services.User;

public interface IUserServices
{
    //Se crea en el servicio el metodo para registrar usuario
    Task<UserResponse> CreateUser(UserRequest UserRequest);
    //Se crea en el servicio el metodo para consultar usuarios
    Task<UserResponse> GetAllUsers();
    //Se crea en el servicio el metodo para editar Usuarios
    Task<UserResponse> UpdateUser(UserRequest UserRequest);
    //Se crea en el servicio el metodo para eliminar usuario
    Task<UserResponse> DeleteUser(UserRequest UserRequest);
    
}
