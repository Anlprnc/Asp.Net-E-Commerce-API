using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Net_E_Commerce.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public int CategoryId { get; set; }
        // public Category Category { get; set; }

        public int BrandId { get; set; }
        // public Brand Brand { get; set; }
    }
}