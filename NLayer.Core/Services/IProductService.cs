using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
    public interface IProductService : IServiceGeneric<Product, ProductDto>
    {
        Task<List<ProductWithCategoryDto>> GetProductsWithCategory();
        Task<List<ProductDto>> GetProductsByIdWithCategory(int categoryId);

    }
}
