using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IARehabilitation.web.Data.Entities
{
    public class TreatmentDetail
    {
        [Key]
        public int Id_DetalleTratamiento { get; set; }
        [Required]
        [ForeignKey("Id_Consulte")]
        public int Id_Consulte { get; set; }
        public Consulte? Consulte { get; set; }

        [Required]
        [ForeignKey("Id_TreatmentDictionary")]
        public int Id_TreatmentDictionary { get; set; }
        public TreatmentDictionary? TreatmentDictionary { get; set; }

    }
}
