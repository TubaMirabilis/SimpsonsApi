using System.Linq.Expressions;
using SimpsonsApi.Entities;
using SimpsonsApi.Models;

namespace SimpsonsApi.Repositories;
public abstract class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : Entity
{
    public abstract IQueryResult<TEntity> GetAll();
    public abstract IQueryResult<TEntity> Get(int pageSize, int pageIndex);
    public abstract TEntity Get(Guid id);
    public abstract IQueryResult<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate);
    public abstract IQueryResult<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex);
    IQueryResult<Entity> IQueryRepository.GetAll()
    {
        return GetAll();
    }
    Entity IQueryRepository.Get(Guid id)
    {
        return Get(id);
    }
    IQueryResult<Entity> IQueryRepository.Get(int pageSize, int pageIndex)
    {
        return Get(pageSize, pageIndex);
    }
}