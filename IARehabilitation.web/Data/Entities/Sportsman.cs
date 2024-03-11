using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IARehabilitation.web.Data.Entities
{
    public class Sportsman
    {
        [Key]
        public int Id_Sportsman { get; set; }
        [Required]
        [Display(Name = "Deporte que practica")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "El deporte debe tener entre 10 y 100 caracteres.")]
        public string? Sport { get; set; }
        [Required]
        [Range(0, 150, ErrorMessage = "La edad debe estar entre 0 y 150.")]
        public int? Age { get; set; }
        [Required]
        [Display(Name = "Género")]
        public bool? Gender { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; } 
        public User? User { get; set; }
        [Required]
        public ICollection<Consulte>? Consultes { get; set; }
    }
}
