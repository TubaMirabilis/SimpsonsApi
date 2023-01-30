using System.Linq.Expressions;
using SimpsonsApi.Entities;
using SimpsonsApi.Models;

namespace SimpsonsApi.Repositories;
public interface IQueryRepository
{
    IQueryResult<Entity> GetAll();
    Entity Get(Guid id);
    IQueryResult<Entity> Get(int pageSize, int pageIndex);
    //IQueryResult<Entity> Get(Expression<Func<Entity, bool>> predicate);
    //IQueryResult<Entity> Get(Expression<Func<Entity, bool>> predicate, int pageSize, int pageIndex);
}
public interface IQueryRepository<TEntity> : IQueryRepository where TEntity : Entity
{
    new IQueryResult<TEntity> GetAll();
    new TEntity Get(Guid id);
    new IQueryResult<TEntity> Get(int pageSize, int pageIndex);
    IQueryResult<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate);
    IQueryResult<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex);
}