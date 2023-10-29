using Api.Models.Financeiro;
using Api.Services.Financeiro.PaymentTermsService.PaymentTermsService;
using Api.Utilities;
using MongoDB.Driver;

namespace Api.Services.Financeiro.PaymentTermsServices
{
    public class PaymentTermsService : IPaymentTermsService
    {
        private readonly IMongoCollection<PaymentTerms> _paymentTerms;

        public PaymentTermsService(ISystemDBConfiguration paymentTermsStoreDatabaseSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(paymentTermsStoreDatabaseSettings.DatabaseName);
            _paymentTerms = database.GetCollection<PaymentTerms>(paymentTermsStoreDatabaseSettings.Collections.FINANCEIRO.PaymentTerms);
        }
        public void Delete(string id)
        {
            _paymentTerms.DeleteOne(paymentTerms => paymentTerms.Id == id);
        }

        public List<PaymentTerms> Get()
        {
            return _paymentTerms.Find(paymentTerms => true).ToList();
        }

        public PaymentTerms Get(string id)
        {
            return _paymentTerms.Find(paymentTerms => paymentTerms.Id == id).FirstOrDefault();
        }

        public PaymentTerms Post(PaymentTerms paymentTerms)
        {
            _paymentTerms.InsertOne(paymentTerms);
            return paymentTerms;
        }

        public void Put(string id, PaymentTerms paymentTerms)
        {
            _paymentTerms.ReplaceOne(paymentTerms => paymentTerms.Id == id, paymentTerms);
        }
    }
}
