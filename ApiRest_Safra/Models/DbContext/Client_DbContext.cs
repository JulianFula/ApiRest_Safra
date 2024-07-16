namespace ApiRest_Safra.Models.DbContext;

public partial class Client_DbContext
{
    public int Id { get; set; }
    public string Document { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public string Email { get; set; }
    public int Bill_Id { get; set; }
    public ICollection<Bill> Bills { get; set; }
}
