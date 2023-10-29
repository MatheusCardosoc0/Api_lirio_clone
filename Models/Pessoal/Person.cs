﻿using Api.Utilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Models.Pessoal
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = GeneratedId.GenerateUniqueStringId(); // Gere um ID único para a pessoa.

        [BsonElement("nameless")]
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int Age { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string IBGE { get; set; } = string.Empty;
        public string Razao { get; set; } = string.Empty;
        public string InscricaoEstadual { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;

        public Group Group { get; set; }

        public City City { get; set; }
    }
}
