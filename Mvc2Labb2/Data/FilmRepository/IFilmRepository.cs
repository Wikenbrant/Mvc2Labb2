using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mvc2Labb2.Data.Paging;
using Mvc2Labb2.Models;
using Mvc2Labb2.Models.Enums;

namespace Mvc2Labb2.Data.FilmRepository
{
    public interface IFilmRepository : IRepositoryBase<Film>
    {
        Task<IEnumerable<Film>> GetAllFilmsAsync();
        Task<IEnumerable<Film>> GetAllFilmsOrderByAsync(string orderOnProperty, OrderByType orderBy);
        Task<PagedResult<Film>> GetAllFilmsPagedAsync(int currentPage, int pageSize);
        Task<PagedResult<Film>> GetAllFilmsOrderByPagedAsync(string orderOnProperty, OrderByType orderBy,int currentPage, int pageSize);
        Task<IEnumerable<Film>> GetFilmsByActorIdAsync(int actorId);
        Task<Film> GetFilmByIdAsync(int filmId);
        Task<Film> GetFilmWithDetailsAsync(int filmId);
        void CreateFilm(Film film);
        void UpdateFilm(Film film);
        void DeleteFilm(Film film);
    }
}