using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mvc2Labb2.Models;

namespace Mvc2Labb2.Data.FilmRepository
{
    public interface IFilmRepository : IRepositoryBase<Film>
    {
        IQueryable<Film> GetAllFilmsAsync();
        IQueryable<Film> GetAllFilmsOrderByAsync(string orderOnProperty, OrderByType orderBy);
        IQueryable<Film> GetFilmsByActorIdAsync(int actorId);
        Task<Film> GetFilmByIdAsync(int filmId);
        Task<Film> GetFilmWithDetailsAsync(int filmId);
        void CreateFilm(Film film);
        void UpdateFilm(Film film);
        void DeleteFilm(Film film);
    }
}