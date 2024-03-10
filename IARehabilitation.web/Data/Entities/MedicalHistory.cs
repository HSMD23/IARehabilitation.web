using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IARehabilitation.web.Data.Entities
{
    public class MedicalHistory
    {
        [Key]
        public int Id_MedicalHistory { get; set; }
        [Required]
        [ForeignKey("Id_Sportsman")]
        public int Id_Sportsman { get; set; }
        [Required]
        [ForeignKey("Id_Professional")]
        public int Id_Professional { get; set; }
        [Required]
        [ForeignKey("Consulte")]
        public int Id_Consulte { get; set; } 
        public Consulte? Consulte { get; set; } 

        [Required]
        [ForeignKey("InjuriesDictionary")]
        public int Id_InjuriesDictionary { get; set; } 
        public InjuriesDictionary? InjuriesDictionary { get; set; } 


    }
}
