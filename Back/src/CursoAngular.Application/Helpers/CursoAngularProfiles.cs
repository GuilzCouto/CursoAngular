using AutoMapper;
using CursoAngular.Application.Dtos;
using CursoAngular.Domain;

namespace CursoAngular.API.Helpers
{
    public class CursoAngularProfiles : Profile
    {
        public CursoAngularProfiles()
        {
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            CreateMap<Palestrante, PalestranteDto>().ReverseMap();
        }
    }
}