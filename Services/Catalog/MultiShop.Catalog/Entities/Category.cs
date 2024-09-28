using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //MongoDb için Id olduğunu belirtiyoruz.
        public string Id { get; set; }
        public string Name { get; set; }

    }
}
