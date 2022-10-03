using API_BusinessAdminCJS.Configurations.Entities;
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
            modelBuilder.ApplyConfiguration(new TipoDocumentoConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            //modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            //modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            //modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();
            //modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();
            //modelBuilder.Entity<Product>().HasIndex(c => c.Name).IsUnique();
            //modelBuilder.Entity<ProductCategory>().HasIndex("ProductId", "CategoryId").IsUnique();
        }
    }
}
