using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Mvc2Labb2.Data.FilmRepository;
using Mvc2Labb2.Data.Paging;
using Mvc2Labb2.Models;
using Mvc2Labb2.Models.Enums;

namespace Mvc2Labb2.Data.Decorators
{
    public class CachedFilmRepository : IFilmRepository
    {
        private readonly IFilmRepository _inner;
        private readonly IMemoryCache _cache;

        private static readonly MemoryCacheEntryOptions CacheEntryOptions =
            new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1));

        public CachedFilmRepository(IFilmRepository inner,IMemoryCache cache)
        {
            _inner = inner;
            _cache = cache;
        }

        public IQueryable<Film> FindAll() => _inner.FindAll();

        public IQueryable<Film> FindByCondition(Expression<Func<Film, bool>> expression) =>
            _inner.FindByCondition(expression);

        public IQueryable<Film> FindAllOrderBy<TKey>(Expression<Func<Film, TKey>> keySelector, OrderByType orderBy) =>
            _inner.FindAllOrderBy(keySelector, orderBy);

        public Task<PagedResult<Film>> FindAllPagedAsync(int currentPage, int pageSize) =>
            _inner.FindAllPagedAsync(currentPage,pageSize);

        public Task<PagedResult<Film>> FindAllOrderByPagedAsync<TKey>(Expression<Func<Film, TKey>> keySelector, OrderByType orderBy, int currentPage, int pageSize) =>
            _inner.FindAllOrderByPagedAsync(keySelector,orderBy,currentPage,pageSize);

        public void Create(Film entity) => _inner.Create(entity);

        public void Update(Film entity) => _inner.Update(entity);

        public void Delete(Film entity) => _inner.Delete(entity);

        public async Task<IEnumerable<Film>> GetAllFilmsAsync()
        {
            var key = $"{nameof(Film)} - {nameof(GetAllFilmsAsync)}";

            if (_cache.TryGetValue<IEnumerable<Film>>(key, out var value)) return value;

            var result = (await _inner.GetAllFilmsAsync().ConfigureAwait(false)).ToList();

            _cache.Set(key, result, CacheEntryOptions);
            return result;
        }

        public async Task<IEnumerable<Film>> GetAllFilmsOrderByAsync(string orderOnProperty, OrderByType orderBy)
        {
            var key = $"{nameof(Film)} - {nameof(GetFilmsByActorIdAsync)} - {orderOnProperty} - {orderBy}";

            if (_cache.TryGetValue<IEnumerable<Film>>(key, out var value)) return value;

            var result = (await _inner.GetAllFilmsOrderByAsync(orderOnProperty, orderBy).ConfigureAwait(false))
                .ToList();

            _cache.Set(key, result, CacheEntryOptions);
            return result;
        }

        public async Task<PagedResult<Film>> GetAllFilmsPagedAsync(int currentPage, int pageSize)
        {
            var key = $"{nameof(Film)} - {nameof(GetFilmsByActorIdAsync)} - {currentPage} - {pageSize}";

            if (_cache.TryGetValue<PagedResult<Film>>(key, out var value)) return value;

            var result = await _inner.GetAllFilmsPagedAsync(currentPage, pageSize).ConfigureAwait(false);

            _cache.Set(key, result, CacheEntryOptions);
            return result;
        }

        public async Task<PagedResult<Film>> GetAllFilmsOrderByPagedAsync(string orderOnProperty, OrderByType orderBy, int currentPage, int pageSize)
        {
            var key = $"{nameof(Film)} - {nameof(GetFilmsByActorIdAsync)} - {orderOnProperty} - {orderBy} - {currentPage} - {pageSize}";

            if (_cache.TryGetValue<PagedResult<Film>>(key, out var value)) return value;

            var result = await _inner.GetAllFilmsOrderByPagedAsync(orderOnProperty, orderBy,currentPage, pageSize).ConfigureAwait(false);

            _cache.Set(key, result, CacheEntryOptions);
            return result;
        }

        public async Task<IEnumerable<Film>> GetFilmsByActorIdAsync(int actorId)
        {
            var key = $"{nameof(Film)} - {nameof(GetFilmsByActorIdAsync)} - {actorId}";

            if (_cache.TryGetValue<IEnumerable<Film>>(key, out var value)) return value;

            var result = (await _inner.GetFilmsByActorIdAsync(actorId).ConfigureAwait(false))
                .ToList();

            _cache.Set(key, result, CacheEntryOptions);
            return result;
        }

        public async Task<Film> GetFilmByIdAsync(int filmId)
        {
            var key = $"{nameof(Film)} - {nameof(GetFilmByIdAsync)} - {filmId}";
            if (_cache.TryGetValue<Film> (key, out var value)) return value;

            var result = await _inner.GetFilmByIdAsync(filmId).ConfigureAwait(false);

            _cache.Set(key, result, CacheEntryOptions);
            return result;
        }

        public async Task<Film> GetFilmWithDetailsAsync(int filmId)
        {
            var key = $"{nameof(Film)} - {nameof(GetFilmWithDetailsAsync)} - {filmId}";
            if (_cache.TryGetValue<Film>(key, out var value)) return value;

            var result = await _inner.GetFilmWithDetailsAsync(filmId).ConfigureAwait(false);

            _cache.Set(key, result, CacheEntryOptions);
            return result;
        }

        public void CreateFilm(Film film) => _inner.CreateFilm(film);

        public void UpdateFilm(Film film) => _inner.UpdateFilm(film);

        public void DeleteFilm(Film film) => _inner.DeleteFilm(film);
    }
}