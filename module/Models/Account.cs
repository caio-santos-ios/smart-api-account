using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public required string Name;
        [BsonElement("email")]
        public required string Email;
        [BsonElement("password")]
        public required string Password;
    }
}