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

        public  IQueryable<Film> GetAllFilmsAsync() =>  FindAll();

        public  IQueryable<Film> GetAllFilmsOrderByAsync(string orderOnProperty,
            OrderByType orderBy) => orderOnProperty switch
        {
            "Titel" =>  FindAllOrderBy(film => film.Title, orderBy),
            "ReleaseYear" =>  FindAllOrderBy(film => film.ReleaseYear, orderBy),
            _ => GetAllFilmsAsync()
        };

        public IQueryable<Film> GetFilmsByActorIdAsync(int actorId) =>
            FindByCondition(film => film.FilmActor.Any(fa => fa.ActorId == actorId));

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