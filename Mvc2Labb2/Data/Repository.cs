using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mvc2Labb2.Data
{
    public class Repository<T> : IRepository<T> where T :class
    {
        private readonly sakilaContext _context;

        public Repository(sakilaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync<TKey>(OrderByType orderBy = OrderByType.None, Expression<Func<T, TKey>> orderByKey = null)
        {
            return (orderByKey, orderBy) switch
            {
                (null, _) => await _context.Set<T>().ToListAsync().ConfigureAwait(false),
                (_, OrderByType.Asc) => await _context.Set<T>().OrderBy(orderByKey).ToListAsync().ConfigureAwait(false),
                (_, OrderByType.Desc) => await _context.Set<T>().OrderByDescending(orderByKey).ToListAsync()
                    .ConfigureAwait(false),
                _ => await _context.Set<T>().ToListAsync().ConfigureAwait(false)
            };
        }

        public async Task<T> GetAsync(int id) => await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
    }
}