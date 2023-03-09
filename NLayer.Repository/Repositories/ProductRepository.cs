using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using Repository.Repositories;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsByIdWithCategory(int categoryId)
        {
           return await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _context.Products.Where(x => x.IsDeleted == false).Include(x => x.Category).ToListAsync();
        }
    }
}
