using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PregledPlus.Models
{
    public class Usluga
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        [Required]
        [DisplayName("Naziv")]
        
        public string naziv{ get; set; }
        [Required]
        [DisplayName("Opis")]
        public string opis { get; set; }
        [Required]
        [DisplayName("Cena")]
        public int cena { get; set; }
    }
}