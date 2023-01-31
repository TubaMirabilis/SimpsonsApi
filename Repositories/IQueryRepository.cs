using System.Linq.Expressions;
using SimpsonsApi.Entities;
using SimpsonsApi.Models;

namespace SimpsonsApi.Repositories;
public interface IQueryRepository
{
    Task<IQueryResult<Entity>> GetAllAsync();
    Task<Entity> GetAsync(Guid id);
    Task<IQueryResult<Entity>> GetAsync(int pageSize, int pageIndex);
}
public interface IQueryRepository<TEntity> : IQueryRepository where TEntity : Entity
{
    new Task<IQueryResult<TEntity>> GetAllAsync();
    new Task<TEntity> GetAsync(Guid id);
    new Task<IQueryResult<TEntity>> GetAsync(int pageSize, int pageIndex);
    Task<IQueryResult<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IQueryResult<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex);
}