using Api.Utilities;

namespace Api.Models.Financeiro
{
    public class Coins
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsUseCreditLimit { get; set; } = false;
    }
}
