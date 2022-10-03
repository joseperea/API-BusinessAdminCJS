using API_BusinessAdminCJS.Data;
using API_BusinessAdminCJS.Data.Entities;
using API_BusinessAdminCJS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API_BusinessAdminCJS.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IGenericRepository<TipoDocumento> _tipoDocumentos;
        IGenericRepository<Usuario> _usuarios;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IGenericRepository<TipoDocumento> TipoDocumentos => _tipoDocumentos  ??= new GenericRepository<TipoDocumento>(_context);
        public IGenericRepository<Usuario> Usuarios => _usuarios ??= new GenericRepository<Usuario>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
