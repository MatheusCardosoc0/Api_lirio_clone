using Api.Models.Pessoal;
using Api.Utilities;

namespace Api.Models.Utilitarios
{
    public class UserSystem
    {
        public string id { get; set; } = GeneratedId.GenerateUniqueStringId();
        public string name { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public Person person { get; set; }
    }
}
