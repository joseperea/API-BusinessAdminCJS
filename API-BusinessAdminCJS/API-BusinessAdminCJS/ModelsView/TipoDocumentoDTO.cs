using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace API_BusinessAdminCJS.ModelsView
{
    public class CreateTipoDocumentoDTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres", MinimumLength = 4)]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres", MinimumLength = 4)]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
    public class TipoDocumentoDTO : CreateTipoDocumentoDTO
    {
        public int Id { get; set; }

        public List<UsuarioDTO> Usuario { get; set; }
    }
}
