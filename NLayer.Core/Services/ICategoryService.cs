using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
    public interface ICategoryService : IServiceGeneric<Category, CategoryDto>
    {
        public Task<CategoryWithProductsDto> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
