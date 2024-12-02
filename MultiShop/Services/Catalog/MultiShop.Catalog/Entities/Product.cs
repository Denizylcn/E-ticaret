using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string productId { get; set; }
        public string productName { get; set; }    
        public string productPrice { get; set; }
        public string productImgUrl { get; set; }
        public string productDescription { get; set; }
        public string productCategoryId { get; set; }
        [BsonIgnore]
        public Category category { get; set; }
        [BsonIgnore]
        public List<ProductImage> productImages { get; set; }  // Ürünle ilişkilendirilen fotoğraflar (List)
    }
}
