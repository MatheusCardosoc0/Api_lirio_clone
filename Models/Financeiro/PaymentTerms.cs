using Api.Utilities;

namespace Api.Models.Financeiro
{
    public class PaymentTerms
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Installments { get; set; } = 1;
    }
}
