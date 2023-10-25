using Api.Models.PaymentTermsModel;

namespace Api.Services.Financeiro.PaymentTermsService.PaymentTermsService
{
    public interface IPaymentTermsService
    {
        List<PaymentTerms> Get();
        PaymentTerms Get(string id);
        PaymentTerms Post(PaymentTerms paymentTerms);
        void Put(string id, PaymentTerms paymentTerms);
        void Delete(string id);
    }
}
