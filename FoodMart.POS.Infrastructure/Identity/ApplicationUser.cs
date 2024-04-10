using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FoodMart.POS.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public bool IsAdmin { get; set; }
    }
}