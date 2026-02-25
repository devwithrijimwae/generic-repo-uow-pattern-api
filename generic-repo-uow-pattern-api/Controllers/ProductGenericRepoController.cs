using generic_repo_pattern_api.Model.Entity;
using generic_repo_pattern_api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace generic_repo_pattern_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGenericRepoController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        public ProductGenericRepoController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await _productRepository.GetAllAsync();
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            var productEntry = new Product()
            {
                ProductName = product.ProductName,
                Price = product.Price
            };
            var createdProduct = await _productRepository.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            var productEntry = await _productRepository.GetByIdAsync(id);
            if (productEntry == null)
            {
                return NotFound();
            }
            productEntry.ProductName = product.ProductName;
            productEntry.Price = product.Price;
            await _productRepository.UpdateAsync(productEntry);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteAsync(product);
            return NoContent();
        }
    }
}

