using Asp.Net_E_Commerce.Core.Entities;
using Asp.Net_E_Commerce.Core.Interfaces;
using Asp.Net_E_Commerce.Core.OtherSubjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts([FromQuery] bool sortByPrice = false, [FromQuery] bool ascending = true)
        {
            var products = await _productService.GetAllProductsAsync(sortByPrice, ascending);
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductById([FromRoute] int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet("brand/{brandId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByBrand([FromRoute] int brandId)
        {
            var products = await _productService.GetProductsByBrandAsync(brandId);
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory([FromRoute] int categoryId)
        {
            var products = await _productService.GetProductsByCategoryAsync(categoryId);
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        // [HttpGet("sorted")]
        // public async Task<ActionResult<IEnumerable<Product>>> GetProductsSortedByPrice([FromQuery] bool ascending = true)
        // {
        //     var products = await _productService.GetProductsSortedAsync(ascending);
        //     if (products == null)
        //         return NotFound();
        //     return Ok(products);
        // }

        // [HttpGet("filtered")]
        // public async Task<ActionResult<IEnumerable<Product>>> GetProductsFilteredByPrice([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        // {
        //     var products = await _productService.GetProductsFilteredByPriceAsync(minPrice, maxPrice);
        //     if (products == null)
        //         return NotFound();
        //     return Ok(products);
        // }

        [HttpPost]
        // [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}")]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            var createdProduct = await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest();

            var updatedProduct = await _productService.UpdateProductAsync(id, product);
            if (updatedProduct == null)
                return NotFound();

            return NoContent();
        }

        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}