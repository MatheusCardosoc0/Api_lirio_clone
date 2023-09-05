using Api.Models.CityModel;
using Api.Services.CityService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cityController : ControllerBase
    {
        private readonly ICityService cityService;

        public cityController(ICityService cityService)
        {
            this.cityService = cityService;
        }
        // GET: api/<cityController>
        [HttpGet]
        public ActionResult<List<City>> Get()
        {
            return cityService.Get();
        }

        // GET api/<cityController>/5
        [HttpGet("{id}")]
        public ActionResult<City> Get(string id)
        {
            var city = cityService.Get(id);

            if(city == null)
            {
                return NotFound($"City with id = {id} not exist");
            }

            return city;
        }

        // POST api/<cityController>
        [HttpPost]
        public ActionResult<City> Post([FromBody] City city)
        {
            cityService.Create(city);

            return CreatedAtAction(nameof(Get), new { id = city.Id }, city);
        }

        // PUT api/<cityController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] City city)
        {
            var existingCity = cityService.Get(id);
            
            if(existingCity == null)
            {
                return NotFound($"City with id = {id} not found");
            }

            cityService.Update(id, city);
            return NoContent(); 

        }

        // DELETE api/<cityController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingCity = cityService.Get(id);

            if( existingCity == null)
            {
                return NotFound($"City with id = {id} not exist");
            }

            cityService.Remove(id);
            return NoContent();
        }
    }
}
