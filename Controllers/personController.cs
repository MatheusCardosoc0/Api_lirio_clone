using Api.Models.PersonModel;
using Api.Services.Person;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class personController : ControllerBase
    {
        private readonly IPersonService userService;

        public personController(IPersonService userService)
        {
            this.userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<Person>> Get()
        {
            return userService.Get();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(string id)
        {
            var user = userService.Get(id);

            if(user == null)
            {
                return NotFound($"User with id = {id} not found");
            }

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person user)
        {
            userService.Create(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user); 
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Person user)
        {
            var existingUser = userService.Get(id);

            if(existingUser == null)
            {
                return NotFound($"User with id = {id} not exist");
            }

            userService.Update(id, user);

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var user = userService.Get(id);

            if(user == null)
            {
                return NotFound($"User with Id = {id} bit found");
            }

            userService.Remove(user.Id);

            return Ok($"User with Id = {id} deleted");
        }
    }
}
