using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string productImagesId {  get; set; }
        public string imageUrl { get; set; }  // Fotoğraf URL'si
        public string description { get; set; }  // Fotoğraf açıklaması (opsiyonel)
      
        public string productId { get; set; }   
        [BsonIgnore]
        public Product Product { get; set; }    
        //Farklı bir şekilde de fotoğraf tutulabilir hatta tutulmalı. 
    }
}
