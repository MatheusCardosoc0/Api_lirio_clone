
using Api.Models.Utilitarios;
using Api.Services.Utilitarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.UTILITARIOS
{
    [Authorize]
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
        public ActionResult<UserSystem> Get(int id)
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
        public ActionResult<UserSystem> Post([FromBody] UserSystem userSystem)
        {
            userService.Post(userSystem);
            return userSystem;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserSystem user)
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
        public ActionResult Delete(int id)
        {
            var user = userService.Get(id);

            if (user == null)
            {
                return NotFound($"User with id = {id} bit found");
            }

            userService.Delete(user.Id);

            return Ok($"User with id = {id} deleted");
        }
    }
}

