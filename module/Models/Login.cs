
using MongoDB.Bson.Serialization.Attributes;

namespace api_account.module.Models
{
    public class Login
    {
        [BsonElement("email")]
        public required string Email { get; set; }
        [BsonElement("password")]
        public required string Password { get; set; }
    }
}