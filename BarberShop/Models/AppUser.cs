using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Name {  get; set; }
        [Required]
        public string LastName {  get; set; }
    }
}
