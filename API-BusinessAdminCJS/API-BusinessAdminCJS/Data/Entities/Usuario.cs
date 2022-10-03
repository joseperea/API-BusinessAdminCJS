using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace API_BusinessAdminCJS.Data.Entities
{
    public class Usuario : IdentityUser
    {

        [ForeignKey(nameof(TipoDocumento))]
        public int IdTipoDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApeliido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }

        //[Display(Name = "Foto")]
        //public Guid ImageId { get; set; }

        //[Display(Name = "Foto")]
        //public string ImageFullPath => ImageId == Guid.Empty
        //    ? $"https://localhost:7057/images/noimage.png"
        //    : $"https://shoppingzulu.blob.core.windows.net/users/{ImageId}";

        //[Display(Name = "Usuario")]
        //public string NombreCompleto => $"{PrimerNombre} {SegundoNombre} {PrimerApeliido} {SegundoApellido}";

        //[Display(Name = "Usuario")]
        //public string FullNameWithDocument => $"{PrimerNombre} {SegundoNombre} {PrimerApeliido} {SegundoApellido} - {Documento}";

        public bool Estado { get; set; }


        //Relaciones 
        public TipoDocumento TipoDocumento { get; set; }
    }
}
