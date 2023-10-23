using Api.Models.GroupModel;
using Api.Services.Pessoal.GroupService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.PESSOAL
{
    [Route("api/[controller]")]
    [ApiController]
    public class groupController : ControllerBase
    {

        private readonly IGroupService groupService;

        public groupController(IGroupService groupService)
        {
            this.groupService = groupService;
        }
        // GET: api/<groupController>
        [HttpGet]
        public ActionResult<List<Group>> Get()
        {
            return groupService.Get();
        }

        // GET api/<groupController>/5
        [HttpGet("{id}")]
        public ActionResult<Group> Get(string id)
        {
            var group = groupService.Get(id);

            if (group == null)
            {
                return NotFound($"Grou with id = {id} not found");
            }

            return group;
        }

        // POST api/<groupController>
        [HttpPost]
        public ActionResult<Group> Post([FromBody] Group group)
        {
            groupService.Create(group);

            return CreatedAtAction(nameof(Get), new { id = group.Id }, group);
        }

        // PUT api/<groupController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Group group)
        {
            var existingGroup = groupService.Get(id);

            if (existingGroup == null)
            {
                return NotFound($"Group with id = {id} not exist");
            }

            groupService.Update(id, group);
            return NoContent();
        }

        // DELETE api/<groupController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var group = groupService.Get(id);

            if (group == null)
            {
                return NotFound($"User with Id = {id} bit found");
            }

            groupService.Remove(group.Id);

            return Ok($"User with Id = {id} deleted");
        }
    }
}
