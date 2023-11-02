using Api.Models.Pessoal;
using Api.Utilities;

namespace Api.Models.Utilitarios
{
    public class UserSystem
    {
        public string Id { get; set; } = GeneratedId.GenerateUniqueStringId();
        public string Name { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public Person Person { get; set; }
    }
}
