using ApiRest_Safra.Models.DTO;

namespace ApiRest_Safra.Models.Client;

public class ClientResponse
{
    public bool response { get; set; }
    public string message { get; set; }
    public List<ClientDTO> ltsClient { get; set; }
}
