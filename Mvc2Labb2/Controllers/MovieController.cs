using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc2Labb2.Data;
using Mvc2Labb2.ViewModels;

namespace Mvc2Labb2.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        // GET
        public async Task<IActionResult> Index(string orderOnProperty, OrderByType? orderByTitle, OrderByType? orderByReleaseYear)
        {
            var orderBy = orderByTitle ?? orderByReleaseYear;
            var viewModel = new ListMovieViewModel
            {
                Items = (await _movieRepository.GetAllAsync(orderOnProperty, orderBy??OrderByType.None).ConfigureAwait(false)).Select(f=>
                    new ListMovieViewModel.MovieViewModel
                    {
                        
                        FilmId = f.FilmId,
                        ReleaseYear = f.ReleaseYear,
                        Title = f.Title
                    }),
                OrderByTitle = orderByTitle ?? OrderByType.None,
                OrderByReleaseYear = orderByReleaseYear ?? OrderByType.None
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var film = await _movieRepository.GetAsync(id).ConfigureAwait(false);
            var viewModel = new MovieDetailViewModel
            {
                Title = film.Title,
                ReleaseYear = film.ReleaseYear,
                Description = film.Description,
                LastUpdate = film.LastUpdate,
                Length = film.Length,
                Rating = film.Rating,
                RentalRate = film.RentalRate,
                ReplacementCost = film.ReplacementCost,
                SpecialFeatures = film.SpecialFeatures
            };
            return View(viewModel);
        }
    }
}