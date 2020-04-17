using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Mvc2Labb2.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class { 

        private readonly sakilaContext _context;

        protected RepositoryBase(sakilaContext context)
        {
            _context = context;
        }
        public IQueryable<T> FindAll() => _context.Set<T>().AsNoTracking();

        public IQueryable<T> FindAllOrderBy<TKey>(Expression<Func<T, TKey>> keySelector, OrderByType orderBy) =>
            (orderBy) switch
            {
                OrderByType.Asc => _context.Set<T>().OrderBy(keySelector).AsNoTracking(),
                OrderByType.Desc => _context.Set<T>().OrderByDescending(keySelector).AsNoTracking(),
                _ => FindAll()
            };

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)=> _context.Set<T>()
            .Where(expression).AsNoTracking();

        public void Create(T entity)=> _context.Set<T>().Add(entity);

        public void Update(T entity)=> _context.Set<T>().Update(entity);

        public void Delete(T entity)=> _context.Set<T>().Remove(entity);
    }
}