using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mvc2Labb2.Data.Paging;
using Mvc2Labb2.Models.Enums;

namespace Mvc2Labb2.Data
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindAllOrderBy<TKey>(Expression<Func<T, TKey>> keySelector, OrderByType orderBy);
        Task<PagedResult<T>> FindAllPagedAsync(int currentPage, int pageSize);
        Task<PagedResult<T>> FindAllOrderByPagedAsync<TKey>(Expression<Func<T, TKey>> keySelector, OrderByType orderBy, int currentPage, int pageSize);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
