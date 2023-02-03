using SimpsonsApi.Entities;
using System.Linq.Expressions;
using SimpsonsApi.Models;

namespace SimpsonsApi.Repositories;
public abstract class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : Entity
{
    public abstract Task<IQueryResult<TEntity>> GetAllAsync();
    public abstract Task<IQueryResult<TEntity>> GetAsync(int pageSize, int pageIndex);
    public abstract Task<TEntity> GetAsync(Guid id);
    public abstract Task<IQueryResult<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate);
    public abstract Task<IQueryResult<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex);
    async Task<IQueryResult<Entity>> IQueryRepository.GetAllAsync()
    {
        return await GetAllAsync();
    }
    async Task<Entity> IQueryRepository.GetAsync(Guid id)
    {
        return await GetAsync(id);
    }
    async Task<IQueryResult<Entity>> IQueryRepository.GetAsync(int pageSize, int pageIndex)
    {
        return await GetAsync(pageSize, pageIndex);
    }
    async Task<IQueryResult<Entity>> IQueryRepository.GetAsync(Expression<Func<Entity, bool>> predicate)
    {
        var passedInType = predicate.Parameters[0].Type;
        if (typeof(TEntity).IsAssignableFrom(passedInType))
        {
            var convertedPredicate = Expression.Lambda<Func<TEntity, bool>>(Expression.Convert(predicate.Body, typeof(bool)),
                Expression.Parameter(typeof(TEntity), predicate.Parameters[0].Name));
            return await GetByExpressionAsync(convertedPredicate);
        }
        throw new ArgumentException(
            $"The type \"{passedInType}\" does not match the type \"{typeof(TEntity)}\"");
    }
    async Task<IQueryResult<Entity>> IQueryRepository.GetAsync(Expression<Func<Entity, bool>> predicate, int pageSize, int pageIndex)
    {
        var passedInType = predicate.Parameters[0].Type;
        if (typeof(TEntity).IsAssignableFrom(passedInType))
        {
            var convertedPredicate = Expression.Lambda<Func<TEntity, bool>>(Expression.Convert(predicate.Body, typeof(bool)),
                Expression.Parameter(typeof(TEntity), predicate.Parameters[0].Name));
            return await GetByExpressionAsync(convertedPredicate, pageSize, pageIndex);
        }
        throw new ArgumentException(
            $"The type \"{passedInType}\" does not match the type \"{typeof(TEntity)}\"");
    }
}