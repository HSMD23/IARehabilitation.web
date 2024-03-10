using System.ComponentModel.DataAnnotations;

namespace IARehabilitation.web.Data.Entities
{
    public class TreatmentDictionary
    {
        [Key]
        public int Id_TreatmentDictionary { get; set; }
        [Required]
        [Display(Name = "Nobre del tratamiento")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "El nombre del tratamiento debe tener entre 10 y 100 caracteres.")]
        public string? Treatment_name { get; set; }
        [Required]
        [Display(Name = "Duracion del tratamiento")]
        [Range(1, int.MaxValue, ErrorMessage = "La duración del tratamiento debe ser un número entero positivo.")]
        //Duracion del tratamiento en dias//
        public int Treatment_length { get; set; }
        [Required]
        // Relación con TreatmentDetail
        public ICollection<TreatmentDetail>? TreatmentDetails { get; set; }

    }
}
