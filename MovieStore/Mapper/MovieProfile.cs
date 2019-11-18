using AutoMapper;
using MovieStore.Models;
using MovieStore.ViewModel;

namespace MovieStore.Mapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieViewModel>();
            CreateMap<MovieViewModel, Movie>();
        }
    }
}
