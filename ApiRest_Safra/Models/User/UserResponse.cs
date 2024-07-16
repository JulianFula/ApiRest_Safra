using ApiRest_Safra.Models.DTO;

namespace ApiRest_Safra.Models.User;

public class UserResponse
{
    public bool response { get; set; }
    public string message { get; set; }
    public List<UserDTO> ltsUsers  { get; set; }
}
