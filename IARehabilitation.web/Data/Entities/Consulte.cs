using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IARehabilitation.web.Data.Entities
{
    public class Consulte
    {
        [Key]
        public int Id_Consulte { get; set; }
        [Required]
        [Display(Name = "Fecha de consulta")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        [Required]
        [Display(Name = "Direccion de la clinica")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "La dirección debe tener entre 10 y 200 caracteres.")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }
        
        [Required]
        [ForeignKey("Id_Sportman")]
        public int? Id_Sportman { get; set; }
        public Sportsman? Sportsman { get; set; }
        
        [Required]
        [ForeignKey("Id_Profesional")]
        public int? Id_Profesional { get; set; }
        public Profesional? Profesional { get; set; }

        // Relación con TreatmentDetail
        public ICollection<TreatmentDetail>? TreatmentDetails { get; set; }

        public ICollection<MedicalHistory>? MedicalHistories { get; set; }

    }
}

