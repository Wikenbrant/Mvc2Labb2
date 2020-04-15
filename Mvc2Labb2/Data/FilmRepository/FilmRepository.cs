using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mvc2Labb2.Models;

namespace Mvc2Labb2.Data.FilmRepository
{
    class FilmRepository : RepositoryBase<Film>,IFilmRepository
    {
        public FilmRepository(sakilaContext context) : base(context){}

        public async Task<IEnumerable<Film>> GetAllFilmsAsync() => await FindAll().ToListAsync().ConfigureAwait(false);

        public async Task<IEnumerable<Film>> GetAllFilmsOrderByAsync(string orderOnProperty,
            OrderByType orderBy = OrderByType.None) => orderOnProperty switch
        {
            "Titel" => await FindAllOrderBy(film => film.Title, orderBy).ToListAsync().ConfigureAwait(false),
            "ReleaseYear" => await FindAllOrderBy(film => film.ReleaseYear, orderBy).ToListAsync()
                .ConfigureAwait(false),
            _ => await GetAllFilmsAsync().ConfigureAwait(false)
        };
        public async Task<IEnumerable<Film>> GetFilmsByActorIdAsync(int actorId) =>
            await FindByCondition(film => film.FilmActor.Any(fa => fa.ActorId == actorId)).ToListAsync()
                .ConfigureAwait(false);

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