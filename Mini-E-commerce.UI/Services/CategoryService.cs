using Dtos;
using System.Text.Json;
using System.Text;

namespace MiniEcommerce.UI.Services
{
    public class CategoryService : IService<CategoryDto, CategoryCreateDto>
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("/api/categories");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var categories = JsonSerializer.Deserialize<IEnumerable<CategoryDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return categories;
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/categories/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var category = JsonSerializer.Deserialize<CategoryDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return category;
        }

        public async Task<CategoryDto> AddAsync(CategoryCreateDto category)
        {
            var content = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/categories", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var createdCategory = JsonSerializer.Deserialize<CategoryDto>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return createdCategory;
        }

        public async Task UpdateAsync(int id, CategoryCreateDto category)
        {
            var content = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/categories/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/categories/{id}");
            response.EnsureSuccessStatusCode();
        }


    }
}
