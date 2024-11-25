using AutoMapper;
using EcoCosechas.DTOs;
using EcoCosechas.Models;

namespace EcoCosechas.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Producto, ProductoDTO>()
                .ForMember(p => p.Subcategoria, e => e.MapFrom(p => p.Subcategoria.Nombre))
                .ForMember(p => p.Marca, e => e.MapFrom(p => p.Marca.Nombre))
                .ForMember(p => p.Unidad, e => e.MapFrom(p => p.Unidad.Nombre));
        }
    }
}
