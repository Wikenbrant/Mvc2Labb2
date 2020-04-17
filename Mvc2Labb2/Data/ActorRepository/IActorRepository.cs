using System.Linq;
using System.Threading.Tasks;
using Mvc2Labb2.Models;
using Mvc2Labb2.Models.Enums;

namespace Mvc2Labb2.Data.ActorRepository
{
    public interface IActorRepository
    {
        IQueryable<Actor> GetAllActorsOrderByAsync(string orderOnProperty, OrderByType orderBy);
        IQueryable<Actor> GetActorsByFilmIdAsync(int filmId);
        Task<Actor> GetActorByIdAsync(int actorId);
        Task<Actor> GetActorWithDetailsAsync(int actorId);
        void CreateActor(Actor actor);
        void UpdateActor(Actor actor);
        void DeleteActor(Actor actor);
    }
}