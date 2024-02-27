using Asp.Net_E_Commerce.Core.Entities;

namespace Asp.Net_E_Commerce.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool sortByPrice = false, bool ascending = true);
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetProductsByBrandAsync(int brandId);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(int id, Product product);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetProductsSortedAsync(bool ascending = true);
        Task<IEnumerable<Product>> GetProductsFilteredByPriceAsync(decimal minPrice, decimal maxPrice);
    }
}
