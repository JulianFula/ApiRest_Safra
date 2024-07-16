using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiRest_Safra.Models.Authorization;
using ApiRest_Safra.Models.DbContext;
using ApiRest_Safra.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_Safra.Services.Authorization;

public class AuthorizationService : IAuthorizationServices
{
    //Se crean variables para el guardado de la configuracion y el uso del Contexto de la base de datos
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _dbContext;
    //Se crea un constructor para retornar la informacion en las variables
    public AuthorizationService(ApplicationDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _configuration = configuration;
    }
    public async Task<AuthorizationResponse> ReturnToken(AuthorizationRequest Authorization)
    {
        //Se busca y valida que exista un usuario con Email y pass en la DB
        var user = _dbContext.User.FirstOrDefault(x =>
            x.UsrEmail == Authorization.email &&
            x.UsrPass == Authorization.password
            );

        var list = _dbContext.User.ToList();

        if (user == null)
        {
            return await Task.FromResult<AuthorizationResponse>(null);
        }
        //Se llama al metodo que genera el token
        string token = GetToken(user.UsrUserId.ToString());

        return new AuthorizationResponse() { Token = token, response = true, message = "Ok" };

    }

    private string GetToken(string idUser)
    {
        //Se obtiene la clave guardada en el AppSettings.Json y se crea un arreglo de bytes usandola
        var key = _configuration.GetValue<string>("JwtSettings:key");

        var keyByte = Encoding.ASCII.GetBytes(key);

        // Verificar la longitud de la clave en bits
        if (keyByte.Length * 8 < 256)
        {
            throw new ArgumentException("The key size must be at least 256 bits.");
        }


        var request = new ClaimsIdentity();
        request.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUser));

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(keyByte),
            SecurityAlgorithms.HmacSha256Signature);

        var token = new SecurityTokenDescriptor
        {
            Subject = request,
            Expires = DateTime.UtcNow.AddMinutes(5),
            SigningCredentials = credentials
        };

        //Se crea el token usando las configuraciones
        var handler = new JwtSecurityTokenHandler();
        var tokenConf = handler.CreateToken(token);

        string returnToken = handler.WriteToken(tokenConf);

        return returnToken;
    }      
}
