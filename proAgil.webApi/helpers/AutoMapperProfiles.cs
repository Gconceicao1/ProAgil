using System.Linq;
using AutoMapper;
using proAgil.Domain;
using proAgil.webApi.Dtos;

namespace proAgil.webApi.helpers
{
    public class AutoMapperProfiles : Profile

    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(dest => dest.Palestrante, opt =>{
                    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.palestrante).ToList());
                }).ReverseMap();
            CreateMap<Palestrante, PalestranteDto>()
                .ForMember(dest => dest.Eventos , opt => {
                    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
                } ).ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
        }    
    }
}