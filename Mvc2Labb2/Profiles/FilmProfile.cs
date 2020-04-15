using AutoMapper;
using Mvc2Labb2.Models;
using Mvc2Labb2.ViewModels;

namespace Mvc2Labb2.Profiles
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            CreateMap<Film, ListMovieViewModel.MovieViewModel>();
            CreateMap<Film, MovieDetailViewModel>();
        }
    }
}