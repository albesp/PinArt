using AutoMapper;
using PinArt.Core.DTOs.Artista;
using PinArt.Core.DTOs.Estilo;
using PinArt.Core.DTOs.Obra;
using PinArt.Core.DTOs.Pais;
using PinArt.Core.DTOs.Tecnica;
using PinArt.Core.Entities;
using System.Linq;

namespace PinArt.Infrastructure.Mapping
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entities To DTOs 

            //Mapear los artistas y obterner los estilos de cada artista en una relación de muchos a muchos
            CreateMap<Artista, GetArtistaDto>()            
            .ForMember(artistadto => artistadto.Estilos, e => e
            .MapFrom(ar => ar.ArtistaEstilos.Select(ae => ae.Estilo)));            

            CreateMap<Obra, GetObraDto>();
            CreateMap<Pais, GetPaisDto>();
            CreateMap<Tecnica, GetTecnicaDto>();
            CreateMap<Estilo, GetEstiloDto>();

            // DTOs To Entities   
            CreateMap<SaveArtistaDto, Artista>().ReverseMap();

            //CreateMap<Movie, MovieDTO>()
            //    .ForMember(MovieDTO =>
            //    MovieDTO.Genre,
            //    opt => opt.MapFrom(src => src.Genre.Name));

            //// DTOs To Entities
            //CreateMap<SaveMovieDTO, Movie>();

            //CreateMap<Security, SecurityDTO>().ReverseMap();


        }
    }
}
