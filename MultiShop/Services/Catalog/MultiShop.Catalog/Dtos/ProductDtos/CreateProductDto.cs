namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
      
        public string productName { get; set; }


        public string productPrice { get; set; }
        public string productImgUrl { get; set; }
        public string productDescription { get; set; }
        public string productCategoryId { get; set; }
    }
}
