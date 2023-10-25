
using Api.Models.PaymentTermsModel;
using Api.Services.Financeiro.PaymentTermsService.PaymentTermsService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.FINANCEIRO
{
    [Route("api/[controller]")]
    [ApiController]
    public class payment_termsController : ControllerBase
    {
        private readonly IPaymentTermsService _paymentTermsService;

        public payment_termsController(IPaymentTermsService paymentTermsService)
        {
            _paymentTermsService = paymentTermsService;
        }
        // GET: api/<payment_termsController>
        [HttpGet]
        public ActionResult<List<PaymentTerms>> Get()
        {
            return _paymentTermsService.Get();
        }

        // GET api/<payment_termsController>/5
        [HttpGet("{id}")]
        public ActionResult<PaymentTerms> Get(string id)
        {
            var exisitingPaymentTerms = _paymentTermsService.Get(id);

            if(exisitingPaymentTerms == null)
            {
                return NotFound($"This PaymentTerms not exist");
            }


            return _paymentTermsService.Get(id);
        }

        // POST api/<payment_termsController>
        [HttpPost]
        public ActionResult<PaymentTerms> Post([FromBody] PaymentTerms paymentTerms)
        {
            return _paymentTermsService.Post(paymentTerms);
        }

        // PUT api/<payment_termsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] PaymentTerms paymentTerms)
        {
            var exisitingPaymentTerms = _paymentTermsService.Get(id);

            if (exisitingPaymentTerms == null)
            {
                return NotFound($"This PaymentTerms not exist");
            }

            _paymentTermsService.Put(id, paymentTerms);

            return NoContent();
        }

        // DELETE api/<payment_termsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var paymentTerms = _paymentTermsService.Get(id);

            if (paymentTerms == null)
            {
                return NotFound($"This PaymentTerms not exist");
            }

            _paymentTermsService.Delete(paymentTerms.Id);
            return NoContent();
        }
    }
}
