using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Mini_E_commerce.Application.Interfaces.Services;
using Models;

namespace Mini_E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private const string CategoryNotFound = "Category not found";
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;

        }

        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllAsync(cat => cat.Products);
            var dtos = _mapper.Map<IEnumerable<CategoryDto>>(categories).ToList();
            return Ok(dtos);
        }






        // GET: api/categories/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetByIdAsync(id, cat => cat.Products);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return Ok(categoryDto);
        }

        // POST: api/categories
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryCreateDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = _mapper.Map<Category>(categoryDto);

            var createdCategory = await _categoryService.AddAsync(category);
            var createdCategoryDto = _mapper.Map<CategoryCreateDto>(createdCategory);

            return CreatedAtAction(nameof(Get), new { id = createdCategoryDto.Id }, createdCategoryDto);
        }

        // PUT: api/categories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryCreateDto categoryToBeUpdatedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound(CategoryNotFound);
            }
            try
            {
                var categoryToBeUpdate = _mapper.Map<Category>(categoryToBeUpdatedDto);

                await _categoryService.UpdateAsync(categoryToBeUpdate);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // DELETE: api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);
            }
            catch (Exception)
            {
                return BadRequest(CategoryNotFound);
            }

            return NoContent();
        }
    }
}
