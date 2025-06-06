namespace PcPartsShop.API.Models
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}
