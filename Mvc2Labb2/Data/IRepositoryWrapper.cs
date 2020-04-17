using System.Threading.Tasks;
using Mvc2Labb2.Data.ActorRepository;
using Mvc2Labb2.Data.FilmRepository;

namespace Mvc2Labb2.Data
{
    public interface IRepositoryWrapper
    {
        IFilmRepository Film { get; }
        IActorRepository Actor { get; }
        Task SaveAsync();
    }
}
