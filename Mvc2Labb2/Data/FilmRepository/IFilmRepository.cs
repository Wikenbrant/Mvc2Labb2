using System.Collections.Generic;
using System.Threading.Tasks;
using Mvc2Labb2.Models;

namespace Mvc2Labb2.Data.FilmRepository
{
    public interface IFilmRepository : IRepositoryBase<Film>
    {
        Task<IEnumerable<Film>> GetAllFilmsAsync();
        Task<IEnumerable<Film>> GetAllFilmsOrderByAsync(string orderOnProperty, OrderByType orderBy = OrderByType.None);
        Task<IEnumerable<Film>> GetFilmsByActorIdAsync(int actorId);
        Task<Film> GetFilmByIdAsync(int filmId);
        Task<Film> GetFilmWithDetailsAsync(int filmId);
        void CreateFilm(Film film);
        void UpdateFilm(Film film);
        void DeleteFilm(Film film);
    }
}