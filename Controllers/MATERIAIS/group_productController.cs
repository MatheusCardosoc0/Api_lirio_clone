using Api.Models.Materiais;
using Api.Services.Materiais.GrouProductService;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.MATERIAIS
{
    [Route("api/[controller]")]
    [ApiController]
    public class group_productController : ControllerBase
    {
        private readonly IGroupProductService groupProductService;
        public group_productController(IGroupProductService groupProductService)
        {
            this.groupProductService = groupProductService;
        }
        // GET: api/<group_productController>
        [HttpGet]
        public ActionResult<List<GroupProduct>> Get()
        {
            return groupProductService.Get();
        }

        // GET api/<group_productController>/5
        [HttpGet("{id}")]
        public ActionResult<GroupProduct> Get(string id)
        {
            var existingGroupProduct = groupProductService.Get(id);

            if (existingGroupProduct == null)
            {
                return NotFound($"GroupProduct not exist");
            }
            return groupProductService.Get(id);
        }

        // POST api/<group_productController>
        [HttpPost]
        public ActionResult<GroupProduct> Post([FromBody] GroupProduct groupProduct)
        {
            groupProductService.Create(groupProduct);
            return CreatedAtAction(nameof(Get), new { id = groupProduct.Id }, groupProduct);
        }

        // PUT api/<group_productController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] GroupProduct groupProduct)
        {
            var existingGroupProduct = groupProductService.Get(id);

            if (existingGroupProduct == null)
            {
                return NotFound($"GroupProduct not exist");
            }

            groupProductService.Update(id, groupProduct);
            return NoContent();
        }

        // DELETE api/<group_productController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingGroupProduct = groupProductService.Get(id);

            if (existingGroupProduct == null)
            {
                return NotFound($"GroupProduct not exist");
            }

            groupProductService.Delete(existingGroupProduct.Id);
            return NoContent();
        }
    }
}
