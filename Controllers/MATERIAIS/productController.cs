using Api.Models.Materiais;
using Api.Services.Materiais.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.MATERIAIS
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly IProductService productService;

        public productController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: api/<productController>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return productService.Get();
        }

        // GET api/<productController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(string id)
        {
            var product = productService.Get(id);

            if (product == null)
            {
                return NotFound($"product not exist");
            }

            return product;
        }

        // POST api/<productController>
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            productService.Create(product);

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT api/<productController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Product product)
        {
            var existingProduct = productService.Get(id);

            if (existingProduct == null)
            {
                return NotFound($"product not found");
            }

            productService.Update(id, product);
            return NoContent();
        }

        // DELETE api/<productController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var product = productService.Get(id);

            if (product == null)
            {
                return NotFound($"Product not exist");
            }

            productService.Delete(product.Id);
            return NoContent();
        }
    }
}
