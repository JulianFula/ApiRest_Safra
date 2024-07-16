namespace ApiRest_Safra.Models.DbContext;

public partial class Bill
{
    public int Id { get; set; }
    public int Client_Id { get; set; }
    public string Company_Name { get; set; }
    public string Nit { get; set; }
    public string Code { get; set; }

    
    public Client_DbContext Client { get; set; }
    public ICollection<Bill_Product> Bill_Products { get; set; }
}
