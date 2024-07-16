using Microsoft.AspNetCore.Mvc;
using ApiRest_Safra.Services.Authorization;
using ApiRest_Safra.Models.Authorization;
using ApiRest_Safra.Models.DTO;
using ApiRest_Safra.Services.User;
using ApiRest_Safra.Models.User;

namespace ApiRest_Safra.Controllers
{
    [Route("api/")]
    [ApiController]
    public class Login : ControllerBase
    {
        
        private readonly IAuthorizationServices _AuthorizationServices;
        
        //constructor
        public Login(IAuthorizationServices authorizationServices, IUserServices userServices)
        {
            _AuthorizationServices = authorizationServices;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> login([FromBody] AuthorizationRequest authorization)
        {
            var result = await _AuthorizationServices.ReturnToken(authorization);
            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);

        }  
    }
}
