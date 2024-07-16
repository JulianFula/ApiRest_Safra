namespace ApiRest_Safra.Models.DbContext;

public partial class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Bill_Product> Bill_Products { get; set; }
}
