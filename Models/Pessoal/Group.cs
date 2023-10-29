using Api.Utilities;

namespace Api.Models.Pessoal
{
    public class Group
    {
        public string Id { get; set; } = GeneratedId.GenerateUniqueStringId();
        public string Name { get; set; }
    }
}
