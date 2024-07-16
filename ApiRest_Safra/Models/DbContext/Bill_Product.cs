namespace ApiRest_Safra.Models.DbContext;

public partial class Bill_Product
{
    public int Id { get; set; }
    public int Bill_Id { get; set; }
    public int Product_Id { get; set; }


    public Bill Bill { get; set; }
    public Product Product { get; set; }
}
