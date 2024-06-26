using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_account.module.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id;

        [BsonElement("name")]
        public required string Name { get; set; }
        [BsonElement("email")]
        public required string Email { get; set; }
        [BsonElement("password")]
        public required string Password { get; set; }
    }
}