using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.DTOs;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;

        public CategoriesController(ProductApiService productApiService, CategoryApiService categoryApiService)
        {
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryApiService.GetAllAsync());
        }
        public async Task<IActionResult> Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryWithProductsDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryApiService.SaveCategoryWithProductsAsync(categoryDto);
                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);

            return View(category);

        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryApiService.UpdateAsync(categoryDto);

                return RedirectToAction(nameof(Index));
            }

            return View(categoryDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _categoryApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
