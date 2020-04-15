using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mvc2Labb2.Models;

namespace Mvc2Labb2.Data.ActorRepository
{
    class ActorRepository : RepositoryBase<Actor>,IActorRepository
    {
        public ActorRepository(sakilaContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Actor>> GetAllActorsAsync() => await FindAll().ToListAsync().ConfigureAwait(false);

        public async Task<IEnumerable<Actor>> GetAllActorsOrderByAsync(string orderOnProperty,
            OrderByType orderBy = OrderByType.None) => orderOnProperty switch
        {
            "FirstName" => await FindAllOrderBy(actor => actor.FirstName, orderBy).ToListAsync().ConfigureAwait(false),
            "LastName" => await FindAllOrderBy(actor => actor.LastName, orderBy).ToListAsync()
                .ConfigureAwait(false),
            _ => await GetAllActorsAsync().ConfigureAwait(false)
        };

        public async Task<IEnumerable<Actor>> GetActorsByFilmIdAsync(int filmId) =>
            await FindByCondition(actor => actor.FilmActor.Any(fa => fa.FilmId == filmId)).ToListAsync()
                .ConfigureAwait(false);

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