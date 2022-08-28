using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API_BusinessAdminCJS.Data.Entities
{
    public class Usuario : IdentityUser
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
        public string Telefono { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Documento { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Direccion { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7057/images/noimage.png"
            : $"https://shoppingzulu.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "Usuario")]
        public string NombreCompleto => $"{PrimerNombre} {SegundoNombre} {PrimerApeliido} {SegundoApellido}";

        [Display(Name = "Usuario")]
        public string FullNameWithDocument => $"{PrimerNombre} {SegundoNombre} {PrimerApeliido} {SegundoApellido} - {Documento}";

        public bool Estado { get; set; }

        public ICollection<TipoDocumento> TipoDocumentos { get; set; }
    }
}
