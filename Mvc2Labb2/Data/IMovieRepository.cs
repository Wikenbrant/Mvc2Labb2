using System.Collections.Generic;
using System.Threading.Tasks;
using Mvc2Labb2.Models;

namespace Mvc2Labb2.Data
{
    public enum OrderByType
    {
        None,
        Asc,
        Desc
    }
    public interface IMovieRepository
    {
        public Task<IEnumerable<Film>> GetAll(string orderOnProperty, OrderByType orderBy = OrderByType.None);
        public Task<Film> Get(int id);
    }
}