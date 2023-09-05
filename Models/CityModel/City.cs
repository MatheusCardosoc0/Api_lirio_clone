using Api.Utilities;

namespace Api.Models.CityModel
{
    public class City
    {
        public string Id { get; set; } = GeneratedId.GenerateUniqueStringId();
        public string Name { get; set; }
        public string IBGNumber { get; set; }
    }
}
