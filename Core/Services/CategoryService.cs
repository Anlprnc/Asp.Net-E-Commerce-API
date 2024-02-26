using Asp.Net_E_Commerce.Core.DbContext;
using Asp.Net_E_Commerce.Core.Entities;
using Asp.Net_E_Commerce.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_E_Commerce.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var categories = await _context.Categories.FindAsync(id);
            if (categories == null)
                return;

            _context.Categories.Remove(categories);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            if (id != category.Id)
            {
                return null;
            }

            _context.Entry(category).State = EntityState.Modified;

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

            return category;
        }

        private bool ProductExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}