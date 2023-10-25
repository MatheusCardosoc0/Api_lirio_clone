using Api.Models.Financeiro.CoinsModel;
using Api.Services.Financeiro.CoinsService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.FINANCEIRO
{
    [Route("api/[controller]")]
    [ApiController]
    public class coinsController : ControllerBase
    {
        private readonly ICoinsService _coinsService;

        public coinsController(ICoinsService coinsService)
        {
            _coinsService = coinsService;
        }

        // GET: api/<Coins>
        [HttpGet]
        public ActionResult<List<Coins>> Get()
        {
            return _coinsService.Get();
        }

        // GET api/<Coins>/5
        [HttpGet("{id}")]
        public ActionResult<Coins> Get(string id)
        {
            var existingCoin = _coinsService.Get(id);

            if(existingCoin != null)
            {
                return NotFound($"Coin not exist");
            }
            return _coinsService.Get(id);
        }

        // POST api/<Coins>
        [HttpPost]
        public ActionResult<Coins> Post([FromBody] Coins coins)
        {
            _coinsService.Post(coins);
            return coins;
        }

        // PUT api/<Coins>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Coins coins)
        {
            var existingCoin = _coinsService.Get(id);

            if (existingCoin != null)
            {
                return NotFound($"Coin not exist");
            }

            _coinsService.Put(id, coins);
            return NoContent();
        }

        // DELETE api/<Coins>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var coin = _coinsService.Get(id);

            if (coin != null)
            {
                return NotFound($"Coin not exist");
            }
            _coinsService.Delete(coin.Id);
            return NoContent();
        }
    }
}
