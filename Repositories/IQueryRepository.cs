using System.Linq.Expressions;
using SimpsonsApi.Entities;
using SimpsonsApi.Models;

namespace SimpsonsApi.Repositories;
public interface IQueryRepository
{
    Task<IQueryResult<Entity>> GetAll();
    Task<Entity> Get(Guid id);
    Task<IQueryResult<Entity>> Get(int pageSize, int pageIndex);
    //IQueryResult<Entity> Get(Expression<Func<Entity, bool>> predicate);
    //IQueryResult<Entity> Get(Expression<Func<Entity, bool>> predicate, int pageSize, int pageIndex);
}
public interface IQueryRepository<TEntity> : IQueryRepository where TEntity : Entity
{
    new Task<IQueryResult<TEntity>> GetAll();
    new Task<TEntity> Get(Guid id);
    new Task<IQueryResult<TEntity>> Get(int pageSize, int pageIndex);
    Task<IQueryResult<TEntity>> GetByExpression(Expression<Func<TEntity, bool>> predicate);
    Task<IQueryResult<TEntity>> GetByExpression(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex);
}