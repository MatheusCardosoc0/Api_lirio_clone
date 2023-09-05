using Api.Utilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Models.PersonModel
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = GeneratedId.GenerateUniqueStringId();
        [BsonElement("nameless")]
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int Age { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
    }
}
