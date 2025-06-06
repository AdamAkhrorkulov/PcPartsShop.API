namespace PcPartsShop.API.DTOs.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string BrandName { get; set; }
        public string CategoryName { get; set; }
    }
}
