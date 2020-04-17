using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc2Labb2.Data;
using Mvc2Labb2.Data.Paging;
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

        public async Task<IActionResult> Index(string propertyName, OrderByType orderBy, int currentPage = 1, int pageSize = 50)
        {
            var movies = await _repository.Film.GetAllFilmsOrderByAsync(propertyName, orderBy).GetPaged(currentPage,pageSize).ConfigureAwait(false);
            var viewModel = new ListMovieViewModel
            {
                Items = _mapper.Map<IEnumerable<ListMovieViewModel.MovieViewModel>>(movies.Results),
                OrderByViewModel =
                {
                    CurrentPropertyName = propertyName,
                    OrderBy = orderBy
                },
                PagingViewModel =
                {
                    CurrentPage = currentPage, 
                    PageSize = pageSize ,
                    LastPage = movies.PageCount
                }
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
            var movies = await _repository.Film.GetFilmsByActorIdAsync(id).ToListAsync().ConfigureAwait(false);
            var viewModel = new ListMovieViewModel
            {
                Items = _mapper.Map<IEnumerable<ListMovieViewModel.MovieViewModel>>(movies)
            };
            return View("Index",viewModel);
        }
    }
}