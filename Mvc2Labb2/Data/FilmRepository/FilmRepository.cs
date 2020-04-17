using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mvc2Labb2.Data.Paging;
using Mvc2Labb2.Models;
using Mvc2Labb2.Models.Enums;

namespace Mvc2Labb2.Data.FilmRepository
{
    class FilmRepository : RepositoryBase<Film>,IFilmRepository
    {
        public FilmRepository(sakilaContext context) : base(context){}

        public async Task<IEnumerable<Film>> GetAllFilmsAsync() => await FindAll().ToListAsync().ConfigureAwait(false);

        public async Task<IEnumerable<Film>> GetAllFilmsOrderByAsync(string orderOnProperty,
            OrderByType orderBy) => orderOnProperty switch
        {
            "Titel" =>  FindAllOrderBy(film => film.Title, orderBy),
            "ReleaseYear" =>  FindAllOrderBy(film => film.ReleaseYear, orderBy),
            _ => await GetAllFilmsAsync().ConfigureAwait(false)
        };

        public Task<PagedResult<Film>> GetAllFilmsPagedAsync(int currentPage, int pageSize) =>
            FindAllPagedAsync(currentPage, pageSize);

        public Task<PagedResult<Film>> GetAllFilmsOrderByPagedAsync(string orderOnProperty, OrderByType orderBy,
            int currentPage, int pageSize) => orderOnProperty switch
        {
            "Titel" => FindAllOrderByPagedAsync(film => film.Title, orderBy, currentPage, pageSize),
            "ReleaseYear" => FindAllOrderByPagedAsync(film => film.ReleaseYear, orderBy, currentPage, pageSize),
            _ => GetAllFilmsPagedAsync(currentPage, pageSize)
        };

        public async Task<IEnumerable<Film>> GetFilmsByActorIdAsync(int actorId) =>
           await FindByCondition(film => film.FilmActor.Any(fa => fa.ActorId == actorId)).ToListAsync().ConfigureAwait(false);

        public Task<Film> GetFilmByIdAsync(int filmId) =>
            FindByCondition(film => film.FilmId == filmId).FirstOrDefaultAsync();

        

        public Task<Film> GetFilmWithDetailsAsync(int filmId) => 
            FindByCondition(film => film.FilmId == filmId)
                .Include(film=>film.FilmActor)
                .ThenInclude(af=>af.Actor)
                .Include(film => film.FilmCategory)
                .ThenInclude(fc=>fc.Category)
                .Include(film => film.Inventory)
                .FirstOrDefaultAsync();

        public void CreateFilm(Film film) => Create(film);

        public void UpdateFilm(Film film) => Update(film);

        public void DeleteFilm(Film film) => Delete(film);


    }
}