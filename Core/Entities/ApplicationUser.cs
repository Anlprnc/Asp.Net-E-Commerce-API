using Microsoft.AspNetCore.Identity;

namespace Asp.Net_E_Commerce.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}