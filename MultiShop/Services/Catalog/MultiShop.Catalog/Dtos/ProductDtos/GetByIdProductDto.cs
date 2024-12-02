namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class GetByIdProductDto
    {
        public string productId { get; set; }
        public string productName { get; set; }


        public string productPrice { get; set; }
        public string productImgUrl { get; set; }
        public string productDescription { get; set; }
        public string productCategoryId { get; set; }
    }
}
