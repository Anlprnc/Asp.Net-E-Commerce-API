using System.ComponentModel.DataAnnotations;

namespace Asp.Net_E_Commerce.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}