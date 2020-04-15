using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mvc2Labb2.Data;
using Mvc2Labb2.ViewModels;

namespace Mvc2Labb2.Controllers
{
    public class MovieController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public MovieController(IRepositoryWrapper repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string orderOnProperty, OrderByType orderByTitle, OrderByType orderByReleaseYear)
        {
            var orderBy = orderByTitle == OrderByType.None ? orderByReleaseYear : orderByTitle;
            var movies = await _repository.Film.GetAllFilmsOrderByAsync(orderOnProperty, orderBy).ConfigureAwait(false);
            var viewModel = new ListMovieViewModel
            {
                Items = _mapper.Map<IEnumerable<ListMovieViewModel.MovieViewModel>>(movies),
                OrderByTitle = orderByTitle ,
                OrderByReleaseYear = orderByReleaseYear
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var film = await _repository.Film.GetFilmWithDetailsAsync(id).ConfigureAwait(false);
            var viewModel = _mapper.Map<MovieDetailViewModel>(film);
            return View(viewModel);
        }
        public async Task<IActionResult> ActorMovies(int id)
        {
            var movies = await _repository.Film.GetFilmsByActorIdAsync(id).ConfigureAwait(false);
            var viewModel = new ListMovieViewModel
            {
                Items = _mapper.Map<IEnumerable<ListMovieViewModel.MovieViewModel>>(movies),
                OrderByTitle = OrderByType.Asc,
                OrderByReleaseYear = OrderByType.None
            };
            return View("Index",viewModel);
        }
    }
}