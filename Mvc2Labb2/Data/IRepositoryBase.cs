using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mvc2Labb2.Data
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindAllOrderBy<TKey>(Expression<Func<T, TKey>> keySelector, OrderByType orderBy);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
