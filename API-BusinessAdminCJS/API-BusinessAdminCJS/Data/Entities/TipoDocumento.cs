using System.ComponentModel.DataAnnotations;

namespace API_BusinessAdminCJS.Data.Entities
{
    public class TipoDocumento
    {
        public int Id { get; set; }      
        public string Nombre { get; set; }       
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual IList<Usuario> Usuarios { get; set; }
    }
}
