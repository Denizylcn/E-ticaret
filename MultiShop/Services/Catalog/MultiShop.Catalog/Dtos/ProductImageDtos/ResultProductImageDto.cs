using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Dtos.ProductImageDtos
{
    public class ResultProductImageDto
    {
        public string productImagesId { get; set; }
        public string imageUrl { get; set; }  // Fotoğraf URL'si
        public string description { get; set; }  // Fotoğraf açıklaması (opsiyonel)

        public string productId { get; set; }
      
    }
}

