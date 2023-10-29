using Api.Utilities;

namespace Api.Models.Financeiro
{
    public class Coins
    {
        public string Id { get; set; } = GeneratedId.GenerateUniqueStringId();
        public string Name { get; set; } = string.Empty;
        public bool IsUseCreditLimit { get; set; } = false;
    }
}
