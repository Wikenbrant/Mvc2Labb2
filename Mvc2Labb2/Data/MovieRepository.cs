using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Film>> GetAllAsync(string orderOnProperty, OrderByType orderBy = OrderByType.None)
        {

            return (orderOnProperty, orderBy) switch
            {
                ("Titel", OrderByType.Asc) => await _context.Film.OrderBy(f => f.Title).ToListAsync().ConfigureAwait(false),
                ("Titel", OrderByType.Desc) => await _context.Film.OrderByDescending(f => f.Title).ToListAsync().ConfigureAwait(false),
                ("ReleaseYear", OrderByType.Asc) => await _context.Film.OrderBy(f => f.ReleaseYear).ToListAsync().ConfigureAwait(false),
                ("ReleaseYear", OrderByType.Desc) => await _context.Film.OrderByDescending(f => f.ReleaseYear).ToListAsync().ConfigureAwait(false),
                _ => await _context.Film.ToListAsync().ConfigureAwait(false)
            };
        }

        public Task<Film> GetAsync(int id) => _context.Film.FirstOrDefaultAsync(f => f.FilmId == id);
    }
}