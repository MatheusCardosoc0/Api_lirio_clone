using Api.Models.Pessoal;

namespace Api.Models.Utilitarios
{
    public class UserSystem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public Person? Person { get; set; }
    }
}
