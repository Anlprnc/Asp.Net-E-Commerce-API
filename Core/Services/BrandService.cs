using Asp.Net_E_Commerce.Core.DbContext;
using Asp.Net_E_Commerce.Core.Entities;
using Asp.Net_E_Commerce.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_E_Commerce.Core.Services
{
    public class BrandService : IBrandService
    {
        private readonly ApplicationDbContext _context;

        public BrandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Brand> CreateBrandAsync(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task DeleteBrandAsync(int id)
        {
            var brands = await _context.Brands.FindAsync(id);
            if (brands == null)
                return;

            _context.Brands.Remove(brands);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Brand>> GetAllBrandAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> GetBrandByIdAsync(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public async Task<Brand> UpdateBrandAsync(int id, Brand brand)
        {
            if (id != brand.Id)
            {
                return null;
            }

            _context.Entry(brand).State = EntityState.Modified;

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

            return brand;
        }

        private bool ProductExists(int id)
        {
            return _context.Brands.Any(e => e.Id == id);
        }
    }
}