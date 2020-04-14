using System.Collections.Generic;
using System.Threading.Tasks;
using Mvc2Labb2.Models;

namespace Mvc2Labb2.Data
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<Film>> GetAll();
        public Task<Film> Get(int id);
    }
}