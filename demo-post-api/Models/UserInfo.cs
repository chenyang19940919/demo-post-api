﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace demo_post_api.Models
{
    public class UserInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("email")]
        public string? Email { get; set; }
        [BsonElement("password")]
        public string? Password { get; set; }
        [BsonElement("name")]
        public string? Name { get; set; }
    }
}
