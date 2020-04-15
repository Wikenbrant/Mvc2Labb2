using System.Collections.Generic;
using System.Threading.Tasks;
using Mvc2Labb2.Models;

namespace Mvc2Labb2.Data.ActorRepository
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetAllActorsAsync();
        Task<IEnumerable<Actor>> GetAllActorsOrderByAsync(string orderOnProperty, OrderByType orderBy = OrderByType.None);
        Task<IEnumerable<Actor>> GetActorsByFilmIdAsync(int filmId);
        Task<Actor> GetActorByIdAsync(int actorId);
        Task<Actor> GetActorWithDetailsAsync(int actorId);
        void CreateActor(Actor actor);
        void UpdateActor(Actor actor);
        void DeleteActor(Actor actor);
    }
}