using System.ComponentModel.DataAnnotations;

namespace IARehabilitation.web.Data.Entities
{
    public class User
    {
        public int UserId { get; set; } 
        [Required]
        [Display(Name = "Nombre(s)")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Apellido Paterno")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        public string? PaternalLastName { get; set; }
        [Required]
        [Display(Name = "Apellido Materno")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        public string? MaternalLastName { get; set; }
        [Required]
        [Display(Name = "Correo electronico")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "Nunmero de celular")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber {  get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        //Relaciones//
     
        public Profesional? Profesional { get; set; }

        public Sportsman? Sportsman { get; set; }
       
    }
}
