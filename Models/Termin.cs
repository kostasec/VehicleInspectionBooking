using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PregledPlus.Models
{
    public class Termin
    {
        
        [Key]
        [DisplayName("Id")]
        public int id { get; set; }
        [Required]
        [DisplayName("Datum")]
        public string? datum { get; set; }
        [Required]
        [DisplayName("Status")]
        public string? status { get; set; }
        [Required]
        [DisplayName("Ime")]
        public string? ime { get; set; }
        [Required]
        [DisplayName("Prezime")]
        public string? prezime { get; set; }
        [Required]
        [DisplayName("Broj telefona")]
        public string? brojTelefona { get; set; }
        [Required]
        [DisplayName("Email")]
        public string? email { get; set; }
        
        [DisplayName("Registracija")]
        public string? reg_oznaka { get; set; }



    }
}
