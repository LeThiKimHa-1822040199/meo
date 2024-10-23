using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string name { get; set; }
        public string? address { get; set; }
    }
}
