using Api.Utilities;

namespace Api.Models.Materiais
{
    public class GroupProduct
    {
        public string Id { get; set; } = GeneratedId.GenerateUniqueStringId();
        public string Name { get; set; }
    }
}
