using System.ComponentModel.DataAnnotations;

namespace Asp.Net_E_Commerce.Core.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string BrandName { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}