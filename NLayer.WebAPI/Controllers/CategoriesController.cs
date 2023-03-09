using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Services;
using NLayer.Service.Services;

namespace NLayer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoriesController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        // api/categories/GetCategoryByIdWithProducts/2
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdWithProducts(int categoryId)
        {
            return Ok(await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SaveCategoryWithProducts(CategoryWithProductsDto categoryDto)
        {
            var category = await _categoryService.AddAsync(new CategoryDto { Name = categoryDto.Name });
            foreach (var product in categoryDto.Products)
            {
                product.CategoryId = category.Id;
            }
            await _productService.AddRangeAsync(categoryDto.Products);
            return Ok(categoryDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(CategoryDto categoryDto)
        {
            await _categoryService.UpdateAsync(categoryDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _categoryService.RemoveAsync(id);
            return Ok();
        }
    }
}
