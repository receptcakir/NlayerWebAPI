using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<CategoryDto>>("categories");
            return response;
        }
        public async Task<CategoryWithProductsDto> GetCategoryByIdWithProductsAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CategoryWithProductsDto>($"categories/GetCategoryByIdWithProducts/{id}");
            return response;
        }
        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CategoryDto>($"categories/{id}");
            return response;
        }

        public async Task<CategoryDto> SaveCategoryWithProductsAsync(CategoryWithProductsDto newCategory)
        {
            var response = await _httpClient.PostAsJsonAsync("categories/SaveCategoryWithProducts", newCategory);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CategoryWithProductsDto>();

            return responseBody;
        }

        public async Task<bool> UpdateAsync(CategoryDto newCategory)
        {
            var response = await _httpClient.PutAsJsonAsync("categories", newCategory);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"categories/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
