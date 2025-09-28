
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PregledPlus.Models
{
    public class Poruka
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        [Required]
        [DisplayName("Ime i prezime")]
        public string ime_prezime { get; set; }
        [Required]
        [DisplayName("Email")]
        public string email { get; set; }
        [Required]
        [DisplayName("Naslov")]
        public string naslov { get; set; }
        [Required]
        [DisplayName("Poruka")]
        public string poruka { get; set; }


    }
}
