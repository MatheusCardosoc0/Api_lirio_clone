using Api.Utilities;

namespace Api.Models.PaymentTermsModel
{
    public class PaymentTerms
    {
        public string Id { get; set; } = GeneratedId.GenerateUniqueStringId();
        public string Name { get; set; } = string.Empty;
        public int Installments { get; set; } = 1;
    }
}
