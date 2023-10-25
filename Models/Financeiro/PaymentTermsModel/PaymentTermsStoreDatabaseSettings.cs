namespace Api.Models.PaymentTermsModel
{
    public class PaymentTermsStoreDatabaseSettings : IPaymentTermsStoreDatabaseSettings
    {
        public string PaymentTermsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
