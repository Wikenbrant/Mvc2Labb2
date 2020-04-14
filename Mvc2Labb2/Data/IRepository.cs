using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mvc2Labb2.Data
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync<TKey>( OrderByType orderBy = OrderByType.None, Expression<Func<T, TKey>> orderByKey = null);
        Task<T> GetAsync(int id);
    }
}
