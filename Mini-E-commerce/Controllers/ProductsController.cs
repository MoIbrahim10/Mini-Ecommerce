using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Mini_E_commerce.Application.Interfaces.Services;
using Mini_E_commerce.Application.Services;
using Models;

namespace Mini_E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private const string ProductNotFound = "Product not found";
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllAsync(pro => pro.Category);
            var dtos = _mapper.Map<IEnumerable<ProductDto>>(products).ToList();
            return Ok(dtos);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetByIdAsync(id, pro => pro.Category);
            if (product == null)
            {
                return NotFound();
            }
            var productDto = _mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCreateDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = _mapper.Map<Product>(productDto);

            var createdProduct = await _productService.AddAsync(product);
            var createdProductDto = _mapper.Map<ProductCreateDto>(createdProduct);

            return CreatedAtAction(nameof(Get), new { id = createdProductDto.Id }, createdProductDto);
        }
        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductCreateDto productToBeUpdatedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound(ProductNotFound);
            }
            try
            {
                var productToBeUpdated = _mapper.Map<Product>(productToBeUpdatedDto);

                await _productService.UpdateAsync(productToBeUpdated);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
            }
            catch (Exception)
            {
                return BadRequest(ProductNotFound);
            }

            return NoContent();
        }
    }
}
