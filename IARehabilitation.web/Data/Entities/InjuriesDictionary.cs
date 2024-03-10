using System.ComponentModel.DataAnnotations;

namespace IARehabilitation.web.Data.Entities
{
    public class InjuriesDictionary
    {
        [Key] 
        public int Id_Injury { get; set; }
        [Required]
        [Display(Name = "Nombre de la lesion")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "El nombre de lesion debe tener entre 10 y 100 caracteres.")]
        public string? Injury_name { get; set; }
        [Required]
        [Display(Name = "Descripcion de la lesion")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "La descripcion debe tener entre 10 y 200 caracteres.")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Categoria de lesion")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "La categoria debe tener entre 10 y 100 caracteres.")]
        public string? Injury_category { get; set; }

        public ICollection<MedicalHistory>? MedicalHistories { get; set; }

    }
}
