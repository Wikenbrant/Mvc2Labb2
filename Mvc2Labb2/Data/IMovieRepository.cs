using System.Collections.Generic;
using System.Threading.Tasks;
using Mvc2Labb2.Models;

namespace Mvc2Labb2.Data
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Film>> GetAllAsync(string orderOnProperty, OrderByType orderBy = OrderByType.None);
        Task<Film> GetAsync(int id);
    }
}