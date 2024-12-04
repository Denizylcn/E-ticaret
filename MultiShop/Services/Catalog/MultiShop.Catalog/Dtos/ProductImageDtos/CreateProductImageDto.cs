namespace MultiShop.Catalog.Dtos.ProductImageDtos
{
    public class CreateProductImageDto
    {

      
        public string imageUrl { get; set; }  // Fotoğraf URL'si
        public string description { get; set; }  // Fotoğraf açıklaması (opsiyonel)

        public string productId { get; set; }
    }
}
