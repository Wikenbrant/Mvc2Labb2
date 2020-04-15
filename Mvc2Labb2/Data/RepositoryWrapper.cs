using System;
using System.Threading.Tasks;
using Mvc2Labb2.Data.ActorRepository;
using Mvc2Labb2.Data.FilmRepository;

namespace Mvc2Labb2.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly sakilaContext _context;

        public RepositoryWrapper(sakilaContext context, IFilmRepository film, IActorRepository actor)
        {
            _context = context;
            Film = film;
            Actor = actor;
        }
        public IFilmRepository Film { get; }
        public IActorRepository Actor { get; }
        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}