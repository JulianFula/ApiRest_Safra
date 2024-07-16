using ApiRest_Safra.Models.Authorization;

namespace ApiRest_Safra.Services.Authorization;

public interface IAuthorizationServices
{
    //Se crea el servicio para devolver el token de autorizacion
    Task<AuthorizationResponse> ReturnToken(AuthorizationRequest autorization);  
}
