using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string productDetailId { get; set; }
        public string productDescription { get; set; }
        public string  productInfo { get; set; }
        public string productId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }    
    }
}
