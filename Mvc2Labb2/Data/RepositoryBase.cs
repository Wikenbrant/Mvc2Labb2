using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mvc2Labb2.Data.Paging;
using Mvc2Labb2.Models.Enums;

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
                OrderByType.Asc => FindAll().OrderBy(keySelector).AsNoTracking(),
                OrderByType.Desc => FindAll().OrderByDescending(keySelector).AsNoTracking(),
                _ => FindAll()
            };


        public Task<PagedResult<T>> FindAllPagedAsync(int currentPage, int pageSize) =>
            FindAll().GetPagedAsync(currentPage, pageSize);

        public Task<PagedResult<T>> FindAllOrderByPagedAsync<TKey>(Expression<Func<T, TKey>> keySelector,
            OrderByType orderBy, int currentPage, int pageSize) =>
            (orderBy) switch
            {
                OrderByType.Asc => _context.Set<T>().OrderBy(keySelector).GetPagedAsync(currentPage, pageSize),
                OrderByType.Desc => _context.Set<T>().OrderByDescending(keySelector)
                    .GetPagedAsync(currentPage, pageSize),
                _ => FindAll().GetPagedAsync(currentPage, pageSize)
            };

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)=> _context.Set<T>()
            .Where(expression).AsNoTracking();

        public void Create(T entity)=> _context.Set<T>().Add(entity);

        public void Update(T entity)=> _context.Set<T>().Update(entity);

        public void Delete(T entity)=> _context.Set<T>().Remove(entity);
    }
}