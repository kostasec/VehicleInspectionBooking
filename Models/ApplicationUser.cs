using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PregledPlus.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Registracija")]
        public string reg_oznaka { get; set; }
        public string? Address { get; set; }
        public string? Town { get; set; }
        [DisplayName("Zip code")]
        public int? ZipCode { get; set; }

        public string? Comment { get; set; }

    }
}
