
using Api.Models.Utilitarios;
using Api.Services.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.UTILITARIOS
{
    [Route("api/[controller]")]
    [ApiController]
    public class users_systemController : ControllerBase
    {
        private readonly IUserSystemService userService;

        public users_systemController(IUserSystemService userService)
        {
            this.userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<UserSystem>> Get()
        {
            return userService.Get();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<UserSystem> Get(string id)
        {
            var user = userService.Get(id);

            if (user == null)
            {
                return NotFound($"User with id = {id} not found");
            }

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<UserSystem> Post([FromBody] UserSystem user)
        {
            userService.Post(user);

            return CreatedAtAction(nameof(Get), new { id = user.id }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] UserSystem user)
        {
            var existingUser = userService.Get(id);

            if (existingUser == null)
            {
                return NotFound($"User with id = {id} not exist");
            }

            userService.Put(id, user);

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var user = userService.Get(id);

            if (user == null)
            {
                return NotFound($"User with id = {id} bit found");
            }

            userService.Delete(user.id);

            return Ok($"User with id = {id} deleted");
        }
    }
}

