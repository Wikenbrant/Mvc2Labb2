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

        public async Task<IEnumerable<Film>> GetAll(string orderOnProperty, OrderByType orderBy = OrderByType.None)
        {

            return (orderOnProperty, orderBy) switch
            {
                ("Titel", OrderByType.Asc) => await _context.Film.OrderBy(f => f.Title).ToListAsync(),
                ("Titel", OrderByType.Desc) => await _context.Film.OrderByDescending(f => f.Title).ToListAsync(),
                ("ReleaseYear", OrderByType.Asc) => await _context.Film.OrderBy(f => f.ReleaseYear).ToListAsync(),
                ("ReleaseYear", OrderByType.Desc) => await _context.Film.OrderByDescending(f => f.ReleaseYear).ToListAsync(),
                _ => await _context.Film.ToListAsync()
            };
        }

        public Task<Film> Get(int id) => _context.Film.FirstOrDefaultAsync(f => f.FilmId == id);
    }
}