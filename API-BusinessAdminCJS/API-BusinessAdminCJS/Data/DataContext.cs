using API_BusinessAdminCJS.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API_BusinessAdminCJS.Data
{
    public class DataContext : IdentityDbContext<Usuario>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            //modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            //modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();
            //modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();
            //modelBuilder.Entity<Product>().HasIndex(c => c.Name).IsUnique();
            //modelBuilder.Entity<ProductCategory>().HasIndex("ProductId", "CategoryId").IsUnique();

            modelBuilder.Entity<TipoDocumento>().HasData(new TipoDocumento { Id = 1, Nombre = "C.C", Descripcion = "Cédula de ciudadanía", Estado = true }
                                                       , new TipoDocumento { Id = 2, Nombre = "T.I", Descripcion = "Tarjeta de identidad", Estado = true }
                                                       , new TipoDocumento { Id = 3, Nombre = "C.E", Descripcion = "Cédula de extranjería", Estado = true }
                                                       , new TipoDocumento { Id = 4, Nombre = "T.E", Descripcion = "Tarjeta de extranjería", Estado = true });
        }
    }
}
