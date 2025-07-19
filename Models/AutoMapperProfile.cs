using AutoMapper;

namespace WebAppApi.Models
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() { 
            CreateMap<Persona, PersonaDTO>();
            CreateMap<Administrador, AdministradorDTO>();
            CreateMap<Direccion, DireccionDTO>();
            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<ReporteEmpresa, ReporteEmpresaDTO>();
            CreateMap<ReporteUsuario, ReporteUsuarioDTO>();
            CreateMap<Inmueble, InmuebleDTO>();
        }
    }
}
