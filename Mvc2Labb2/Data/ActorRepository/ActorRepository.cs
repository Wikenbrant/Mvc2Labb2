using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mvc2Labb2.Models;
using Mvc2Labb2.Models.Enums;

namespace Mvc2Labb2.Data.ActorRepository
{
    class ActorRepository : RepositoryBase<Actor>,IActorRepository
    {
        public ActorRepository(sakilaContext context) : base(context)
        {
        }
        public  IQueryable<Actor> GetAllActorsAsync() =>  FindAll();

        public  IQueryable<Actor> GetAllActorsOrderByAsync(string orderOnProperty,
            OrderByType orderBy) => orderOnProperty switch
        {
            "FirstName" =>  FindAllOrderBy(actor => actor.FirstName, orderBy),
            "LastName" =>  FindAllOrderBy(actor => actor.LastName, orderBy),
            _ =>  GetAllActorsAsync()
        };

        public  IQueryable<Actor> GetActorsByFilmIdAsync(int filmId) =>
             FindByCondition(actor => actor.FilmActor.Any(fa => fa.FilmId == filmId));

        public Task<Actor> GetActorByIdAsync(int actorId) =>
            FindByCondition(actor => actor.ActorId == actorId).FirstOrDefaultAsync();

        public Task<Actor> GetActorWithDetailsAsync(int actorId) =>
            FindByCondition(actor => actor.ActorId == actorId)
                .Include(actor => actor.FilmActor)
                .ThenInclude(af => af.Film)
                .FirstOrDefaultAsync();

        public void CreateActor(Actor actor) => Create(actor);

        public void UpdateActor(Actor actor) => Update(actor);

        public void DeleteActor(Actor actor) => Delete(actor);


    }
}