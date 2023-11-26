using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Models.Pessoal
{
    public class Person
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("nameless")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
        public string BirthDate { get; set; }
        public string IBGE { get; set; }
        public string Razao { get; set; }
        public string InscricaoEstadual { get; set; }
        public string CEP { get; set; }
        public string? urlImage { get; set; } = string.Empty;
        public bool? isBlocked { get; set; } = false;
        public string? MaritalStatus { get; set; } = string.Empty;
        public string? Habilities { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public Group Group { get; set; }

        public City City { get; set; }
    }
}
