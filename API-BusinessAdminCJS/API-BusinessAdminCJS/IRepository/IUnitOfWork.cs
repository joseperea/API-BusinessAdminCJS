using API_BusinessAdminCJS.Data.Entities;

namespace API_BusinessAdminCJS.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TipoDocumento> TipoDocumentos { get; }

        IGenericRepository<Usuario> Usuarios { get; }

        Task Save();
    }
}
