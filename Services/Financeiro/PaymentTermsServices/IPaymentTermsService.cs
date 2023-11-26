using Api.Models.Financeiro;

namespace Api.Services.Financeiro.PaymentTermsService.PaymentTermsService
{
    public interface IPaymentTermsService
    {
        List<PaymentTerms> Get();
        PaymentTerms Get(int id);
        PaymentTerms Post(PaymentTerms paymentTerms);
        void Put(int id, PaymentTerms paymentTerms);
        void Delete(int id);
    }
}
