using SimpsonsApi.Entities;
using SimpsonsApi.Paging;
namespace SimpsonsApi.Models;
public interface IQueryResult
{
    PagingDescriptor PagingDescriptor { get; }
    int ActualPageZeroIndex { get; }
    IEnumerable<Entity> Results { get; }
}
public interface IQueryResult<out TEntity> : IQueryResult where TEntity : Entity
{
    new IEnumerable<TEntity> Results { get; }
}