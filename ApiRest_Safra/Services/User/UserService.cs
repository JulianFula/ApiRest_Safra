using ApiRest_Safra.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using ApiRest_Safra.Models.DbContext;
using Microsoft.EntityFrameworkCore;
using ApiRest_Safra.Models.User;
using ApiRest_Safra.Models.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using ApiRest_Safra.Controllers;

namespace ApiRest_Safra.Services.User;

public class UserService : IUserServices
{
    //Se crean variables para el guardado de la configuracion y el uso del Contexto de la base de datos
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _dbContext;
    //Se crea un constructor para retornar la informacion en las variables
    public UserService(ApplicationDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _configuration = configuration;
    }

    public async Task<UserResponse> CreateUser(UserRequest UserRequest)
    {
        if (UserRequest == null)
        {
            return new UserResponse() { response = true, message = "Bad" };
        }

        User_DbContext user_Db = new User_DbContext {
            UsrPass = UserRequest.password,
            UsrEmail = UserRequest.email
        };

        _dbContext.User.Add(user_Db);

        await _dbContext.SaveChangesAsync();

        return new UserResponse() {response = true, message = "Ok" };

    }

    public async Task<UserResponse> GetAllUsers()
    {

        UserResponse userResponse = new UserResponse();

        // Consulta para obtener los usuarios y mapearlos a DTOs
        List<UserDTO> users = await _dbContext.User
            .Select(u => new UserDTO
            {
                UsrUserId = u.UsrUserId, 
                UsrEmail = u.UsrEmail,
                UsrPass = u.UsrPass,
            })
            .ToListAsync();

        // Preparar la respuesta
        userResponse.response = true;
        userResponse.message = "Ok";
        userResponse.ltsUsers = users;

        return userResponse;
        
    }

    public async Task<UserResponse> DeleteUser(int Id)
    {
        var user = await _dbContext.User.FindAsync(Id);

        if (user == null)
        {
            return new UserResponse() { response = true, message = "Not Found" };
        }

        _dbContext.User.Remove(user);
        await _dbContext.SaveChangesAsync();

        return new UserResponse() { response = true, message = "Registro Eliminado" };
    }

    public async Task<UserResponse> UpdateUser(UserDTO UserRequest)
    {
        var user = await _dbContext.User.FindAsync(UserRequest.UsrUserId);

        if (user == null)
        {
            return new UserResponse() { response = true, message = "Not Found" };
        }

        user.UsrEmail = UserRequest.UsrEmail;
        user.UsrPass = UserRequest.UsrPass;

        await _dbContext.SaveChangesAsync();

        return new UserResponse() { response = true, message = "Registro Editado Correctamente" };
    }
}
