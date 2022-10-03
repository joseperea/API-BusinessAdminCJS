using API_BusinessAdminCJS.Data.Entities;
using API_BusinessAdminCJS.ModelsView;
using AutoMapper;

namespace API_BusinessAdminCJS.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<TipoDocumento, TipoDocumentoDTO>().ReverseMap();
            CreateMap<TipoDocumento, CreateTipoDocumentoDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, LoginUserDTO>().ReverseMap();
        }
    }
}