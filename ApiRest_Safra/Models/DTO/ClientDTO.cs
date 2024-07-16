using ApiRest_Safra.Models.DbContext;

namespace ApiRest_Safra.Models.DTO;

public class ClientDTO
{
    public int Id { get; set; }
    public string Document { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public string Email { get; set; }
    public int Bill_Id { get; set; }
    public Bill Bill { get; set; }
}
