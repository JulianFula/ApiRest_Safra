using ApiRest_Safra.Models.Client;
using ApiRest_Safra.Services.Client;
using ApiRest_Safra.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_Safra.Controllers;

[Route("api/")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientServices _ClientServices;
    //constructor
    public ClientsController(IClientServices clientServices)
    {
        _ClientServices = clientServices;
    }

    [HttpGet]
    [Route("GetAllClients")]
    public async Task<IActionResult> GetAllClients()
    {
        var result = await _ClientServices.GetAllClients();
        if (result == null)
        {
            return Unauthorized();
        }
        return Ok(result);
    }

    [HttpGet("ExportClientsToCsv")]
    public async Task<IActionResult> ExportClientsToCsv()
    {
        var memoryStream = await _ClientServices.ExportClientsToCsv();

        return File(memoryStream, "text/csv", "clients.csv");
    }

    [HttpPost("UploadClientsCSV")]
    public async Task<IActionResult> UploadClientsCSV(IFormFile file)
    {
        var ClientResponse = await _ClientServices.UploadClientsCSV(file);

        if (ClientResponse == null)
        {
            return Unauthorized();
        }

        return Ok(ClientResponse.message);
    }

    
}
