using Api.Utilities;

namespace Api.Models.Pessoal
{
    public class City
    {
        public string Id { get; set; } = GeneratedId.GenerateUniqueStringId();
        public string Name { get; set; }
        public string IBGNumber { get; set; }
        public string State { get; set; }
    }
}
