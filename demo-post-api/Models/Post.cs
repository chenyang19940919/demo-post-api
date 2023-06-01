using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace demo_post_api.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("thumbnail")]
        public string? Thumbnail { get; set; }

        [BsonElement("content")]
        public string? Content { get; set; }

        [BsonElement("status")]
        public int Status { get; set; }

        [BsonElement("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}
