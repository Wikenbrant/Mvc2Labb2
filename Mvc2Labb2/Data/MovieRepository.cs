using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mvc2Labb2.Models;

namespace Mvc2Labb2.Data
{
    class MovieRepository : IMovieRepository
    {
        private readonly sakilaContext _context;

        public MovieRepository(sakilaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Film>> GetAll() => await _context.Film.ToListAsync();

        public Task<Film> Get(int id) => _context.Film.FirstOrDefaultAsync(f => f.FilmId == id);
    }
}