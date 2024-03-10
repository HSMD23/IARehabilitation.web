using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IARehabilitation.web.Data.Entities
{
    public class Profesional
    {
        [Key]
        public int Id_Profesional { get; set; }
        //Cedula profesional compuesta por 15 numeros//
        [Required]
        [Display(Name = "Numero de celula profesional")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "El número de cédula debe tener exactamente 15 dígitos.")]
        public string? ProfessionalLicence { get; set; }
        [Required]
        [Display(Name = "Especialidad del Profesional")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "La especialidad debe tener entre 10 y 100 caracteres.")]
        public string? Speciality { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; } // Clave Foránea
        public User? User { get; set; }
        [Required]
        public ICollection<Consulte>? Consultes { get; set; }
    }
}
