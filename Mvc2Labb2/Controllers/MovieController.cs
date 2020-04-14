
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
        public async Task<IActionResult> Index()
        {
            var viewModel = new ListMovieViewModel
            {
                Items = (await _movieRepository.GetAll()).Select(f=>
                    new ListMovieViewModel.MovieViewModel
                    {
                        FilmId = f.FilmId,
                        ReleaseYear = f.
                            ReleaseYear,Title = f.Title
                    })
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var film = await _movieRepository.Get(id);
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