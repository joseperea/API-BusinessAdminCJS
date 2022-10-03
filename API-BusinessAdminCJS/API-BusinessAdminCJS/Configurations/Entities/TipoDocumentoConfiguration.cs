using API_BusinessAdminCJS.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_BusinessAdminCJS.Configurations.Entities
{
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder)
        {
            builder.HasData(
                new TipoDocumento { Id = 1, Nombre = "C.C", Descripcion = "Cédula de ciudadanía", Estado = true }
                                                       , new TipoDocumento { Id = 2, Nombre = "T.I", Descripcion = "Tarjeta de identidad", Estado = true }
                                                       , new TipoDocumento { Id = 3, Nombre = "C.E", Descripcion = "Cédula de extranjería", Estado = true }
                                                       , new TipoDocumento { Id = 4, Nombre = "T.E", Descripcion = "Tarjeta de extranjería", Estado = true }
                );
        }
    }
}
