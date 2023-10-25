namespace Api.Models.PaymentTermsModel
{
    public interface IPaymentTermsStoreDatabaseSettings
    {
        string PaymentTermsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
