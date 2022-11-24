using AutoMapper;
using VentasAPI.DTOs.DtosInput;
using VentasAPI.DTOs.DtosOutput;
using VentasAPI.Entidades;

namespace VentasAPI.Mappings
{
    public class ProductoCrearProfile : Profile
    {
        public ProductoCrearProfile()
        {
            CreateMap<ProductoDtoCrear, Producto>()
                .ForMember(
                dest => dest.Descripcion,
                opt => opt.MapFrom(src => $"{src.Descripcion}")
                );

            CreateMap<ProductoDtoCrear, Producto>()
                .ForMember(
                dest => dest.Precio,
                opt => opt.MapFrom(src => $"{src.Precio}")
                );
        }
    }
    public class ProductoModificarProfile : Profile
    {
        public ProductoModificarProfile()
        {
            CreateMap<ProductoDtoModificar, Producto>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.Id}")
                );

            CreateMap<ProductoDtoModificar, Producto>()
                .ForMember(
                dest => dest.Descripcion,
                opt => opt.MapFrom(src => $"{src.Descripcion}")
                );

            CreateMap<ProductoDtoModificar, Producto>()
                .ForMember(
                dest => dest.Precio,
                opt => opt.MapFrom(src => $"{src.Precio}")
                );
        }
    }
    public class ProductoOutputProfile : Profile
    {
        public ProductoOutputProfile()
        {
            CreateMap<Producto, ProductoDtoOutput>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.Id}")
                );

            CreateMap<Producto, ProductoDtoOutput>()
                .ForMember(
                dest => dest.Descripcion,
                opt => opt.MapFrom(src => $"{src.Descripcion}")
                );

            CreateMap<Producto, ProductoDtoOutput>()
                .ForMember(
                dest => dest.Precio,
                opt => opt.MapFrom(src => $"{src.Precio}")
                );
        }
    }
}
