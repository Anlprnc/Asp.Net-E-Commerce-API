using Asp.Net_E_Commerce.Core.DbContext;
using Asp.Net_E_Commerce.Core.Entities;
using Asp.Net_E_Commerce.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_E_Commerce.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool sortByPrice = false, bool ascending = true)
        {
            if (sortByPrice)
            {
                if (ascending)
                    return await _context.Products.OrderBy(p => p.Price).ToListAsync();
                else
                    return await _context.Products.OrderByDescending(p => p.Price).ToListAsync();
            }
            else
            {
                return await _context.Products.ToListAsync();
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByBrandAsync(int brandId)
        {
            return await _context.Products.Where(b => b.BrandId == brandId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsFilteredByPriceAsync(decimal minPrice, decimal maxPrice)
        {
            return await _context.Products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsSortedAsync(bool ascending = true)
        {
            if (ascending)
                return await _context.Products.OrderBy(p => p.Price).ToListAsync();
            else
                return await _context.Products.OrderByDescending(p => p.Price).ToListAsync();
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            if (id != product.Id)
            {
                return null;
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}