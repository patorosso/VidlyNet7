using AutoMapper;
using VidlyNet7.Dtos;
using VidlyNet7.Models;

namespace VidlyNet7
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<Genre, GenreDto>();


        }
    }
}
