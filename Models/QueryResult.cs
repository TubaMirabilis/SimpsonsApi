using SimpsonsApi.Entities;
using SimpsonsApi.Paging;
namespace SimpsonsApi.Models;
public class QueryResult<TEntity> : IQueryResult<TEntity> where TEntity : Entity
{
    public QueryResult(
        PagingDescriptor pagingDescriptor,
        int actualPageZeroIndex,
        IEnumerable<TEntity> results)
    {
        PagingDescriptor = pagingDescriptor;
        ActualPageZeroIndex = actualPageZeroIndex;
        Results = results;
    }
    public PagingDescriptor PagingDescriptor { get; }
    public int ActualPageZeroIndex { get; }
    public IEnumerable<TEntity> Results { get; }
    IEnumerable<Entity> IQueryResult.Results => Results;
}