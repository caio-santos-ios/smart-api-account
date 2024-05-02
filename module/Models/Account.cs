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
        [BsonElement("active")]
        public bool Active { get; set; } = true;
        [BsonElement("created_at")]
        public DateTime? CreatedAt { get;} = new DateTime();
        [BsonElement("updated_at")]
        public DateTime? UpdatedAt { get;} = new DateTime();
        [BsonElement("deleted_at")]
        public DateTime? DeletedAt { get;} = new DateTime();
    }
}