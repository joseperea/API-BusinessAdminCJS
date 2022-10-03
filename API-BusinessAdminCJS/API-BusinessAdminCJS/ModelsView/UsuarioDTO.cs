using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace API_BusinessAdminCJS.ModelsView
{

    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres", MinimumLength = 4)]
        public string Password { get; set; }
    }

    public class UsuarioDTO : LoginUserDTO
    {
        [Display(Name = "Primer Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string PrimerNombre { get; set; }

        [Display(Name = "Segundo Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string SegundoNombre { get; set; }

        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string PrimerApeliido { get; set; }

        [Display(Name = "Segundo Apellido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string SegundoApellido { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Numero Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Documento { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Direccion { get; set; }

        [Display(Name = "Tipo Documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int IdTipoDocumento { get; set; }

        public ICollection<string> Roles { get; set; }

    }
}
