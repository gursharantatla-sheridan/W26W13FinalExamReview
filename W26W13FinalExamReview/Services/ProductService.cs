using Microsoft.EntityFrameworkCore;
using W26W13FinalExamReview.Data;
using W26W13FinalExamReview.Models;

namespace W26W13FinalExamReview.Services
{
    public class ProductService
    {
        private ProductContext _context;

        public ProductService(ProductContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Product>> GetProductsAsync(string? searchKeyword = null)
        {
            var products = _context.Products
                                   .Include(p => p.Category)
                                   .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                products = products.Where(p => p.ProductName.Contains(searchKeyword));
            }

            return await products.ToListAsync();
        }
    }
}
