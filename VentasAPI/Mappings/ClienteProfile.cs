using AutoMapper;
using VentasAPI.DTOs.DtosInput;
using VentasAPI.DTOs.DtosOutput;
using VentasAPI.Entidades;

namespace VentasAPI.Mappings
{
    public class ClienteCrearProfile : Profile
    {
        public ClienteCrearProfile()
        {
            CreateMap<ClienteDtoCrear, Cliente>()
                .ForMember(
                dest => dest.Nombre, 
                opt => opt.MapFrom(src => $"{src.Nombre}")
                );
        }
    }
    public class ClienteModificarProfile : Profile
    {
        public ClienteModificarProfile()
        {
            CreateMap<ClienteDtoModificar, Cliente>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.Id}")
                );

            CreateMap<ClienteDtoModificar, Cliente>()
                .ForMember(
                dest => dest.Nombre,
                opt => opt.MapFrom(src => $"{src.Nombre}")
                );
        }
    }
    public class ClienteOutputProfile : Profile
    {
        public ClienteOutputProfile()
        {
            CreateMap<Cliente, ClienteDtoOutput>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.Id}")
                );

            CreateMap<Cliente, ClienteDtoOutput>()
                .ForMember(
                dest => dest.Nombre,
                opt => opt.MapFrom(src => $"{src.Nombre}")
                );
        }
    }
}
