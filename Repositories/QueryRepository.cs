using SimpsonsApi.Entities;
using System.Linq.Expressions;
using SimpsonsApi.Models;

namespace SimpsonsApi.Repositories;
public abstract class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : Entity
{
    public abstract Task<IQueryResult<TEntity>> GetAll();
    public abstract Task<IQueryResult<TEntity>> Get(int pageSize, int pageIndex);
    public abstract TEntity Get(Guid id);
    public abstract Task<IQueryResult<TEntity>> GetByExpression(Expression<Func<TEntity, bool>> predicate);
    public abstract Task<IQueryResult<TEntity>> GetByExpression(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex);
    async Task<IQueryResult<Entity>> IQueryRepository.GetAll()
    {
        return await GetAll();
    }
    Entity IQueryRepository.Get(Guid id)
    {
        return Get(id);
    }
    async Task<IQueryResult<Entity>> IQueryRepository.Get(int pageSize, int pageIndex)
    {
        return await Get(pageSize, pageIndex);
    }
}