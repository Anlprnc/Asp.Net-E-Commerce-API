using System.ComponentModel.DataAnnotations;

namespace Asp.Net_E_Commerce.Core.Dtos
{
    public class UpdatePermissionDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
    }
}