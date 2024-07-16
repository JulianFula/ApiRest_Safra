using ApiRest_Safra.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;
using CsvHelper;
using ApiRest_Safra.Models.DTO;
using ApiRest_Safra.Models.Client;
using ApiRest_Safra.Models.DbContext;
using CsvHelper.Configuration;

namespace ApiRest_Safra.Services.Client;

public class ClientService : IClientServices
{
    //Se crean variables para el guardado de la configuracion y el uso del Contexto de la base de datos
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _dbContext;
    //Se crea un constructor para retornar la informacion en las variables
    public ClientService(ApplicationDbContext context, IConfiguration configuration)
    {
        _dbContext = context;
        _configuration = configuration;
    }

    public Task<ClientResponse> CreateUser(UserRequest UserRequest)
    {
        throw new NotImplementedException();
    }

    public Task<ClientResponse> DeleteUser(UserRequest UserRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<MemoryStream> ExportClientsToCsv()
    {
        var clients = await _dbContext.Client.ToListAsync();

        var memoryStream = new MemoryStream();
        var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);
        var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        csvWriter.WriteRecords(clients);

        await csvWriter.FlushAsync();
        await streamWriter.FlushAsync();

        memoryStream.Seek(0, SeekOrigin.Begin);

        return memoryStream;
    }

    public async Task<ClientResponse> UploadClientsCSV(IFormFile file)
    {
        if(file == null || file.Length == 0)
        {
            return new ClientResponse() { response = false, message = "Archivo no encontrado o vacío."};
        }

        // Procesar el archivo CSV
        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null, // Esto omite la validación de campos faltantes
                BadDataFound = null // Esto omite la validación de datos incorrectos
            };

            using (var csv = new CsvReader(reader, csvConfig))
            {
                var records = csv.GetRecords<Client_DbContext>().ToList();


                var clients = records.Select(record => new Client_DbContext
                {
                    First_Name = record.First_Name,
                    Last_Name = record.Last_Name,
                    Email = record.Email,
                    Document = record.Document,
                    Bill_Id = record.Bill_Id,
                }).ToList();

                _dbContext.Client.AddRange(clients);
                await _dbContext.SaveChangesAsync();

                return new ClientResponse() { response = false, message = "Clientes cargados exitosamente desde el archivo CSV." };
            }
        }     
    }

    public async Task<ClientResponse> GetAllClients()
    {
        ClientResponse clientResponse = new ClientResponse();

        // Consulta para obtener los clientes y mapearlos a DTOs
        List<ClientDTO> client = await _dbContext.Client
            .Select(u => new ClientDTO
            {
                Id = u.Id,
                First_Name = u.First_Name,
                Last_Name = u.Last_Name,
                Document = u.Document,
                Email = u.Email,
                Bill_Id = u.Bill_Id,
            })
            .ToListAsync();

        // Preparar la respuesta
        clientResponse.response = true;
        clientResponse.message = "Ok";
        clientResponse.ltsClient = client;

        return clientResponse;
    }

    public Task<ClientResponse> UpdateUser(UserRequest UserRequest)
    {
        throw new NotImplementedException();
    }
}
