namespace ApiRest_Safra.Models.User;
using ApiRest_Safra.Models.DTO;

public class UserRequest
{
    public string email { get; set; }
    public string password { get; set; }
    public UserDTO UserDTO { get; set; }
}
