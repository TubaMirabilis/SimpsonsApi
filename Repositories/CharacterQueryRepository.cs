using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SimpsonsApi.Data;
using SimpsonsApi.Entities;
using SimpsonsApi.Extensions;
using SimpsonsApi.Models;
namespace SimpsonsApi.Repositories;
public class CharacterQueryRepository : QueryRepository<Character>
{
    private readonly int maxResultsCountPerPage = 5;
    private readonly ApplicationDbContext _ctx;
    public CharacterQueryRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }
    public override async Task<IQueryResult<Character>> GetAll()
    {
        return await Get(c => true, null, null);
    }
    public override async Task<Character> Get(Guid id)
    {
        var c = await _ctx.Characters!.FirstOrDefaultAsync(c => c.Id == id);
        ArgumentNullException.ThrowIfNull(c);
        return c;
    }
    public override async Task<IQueryResult<Character>> Get(int pageSize, int pageIndex)
    {
        return await Get(c => true, pageSize, pageIndex);
    }
    public override async Task<IQueryResult<Character>> GetByExpression(Expression<Func<Character, bool>> predicate)
    {
        return await Get(predicate, null, null);
    }
    public override async Task<IQueryResult<Character>> GetByExpression(Expression<Func<Character, bool>> predicate, int pageSize, int pageIndex)
    {
        return await Get(predicate, pageSize, pageIndex);
    }
    private async Task<IQueryResult<Character>> Get(Expression<Func<Character, bool>> predicate, int? pageSize, int? pageIndex)
    {
        var filteredItems =
            predicate != null ?
                await _ctx.Characters!.AsQueryable().Where(predicate).ToListAsync() :
                await _ctx.Characters!.ToListAsync();
        ArgumentNullException.ThrowIfNull(filteredItems);
        var finalPageSize = Math.Min(maxResultsCountPerPage, filteredItems.Count);
        var finalPageIndex = 0;
        if (pageSize != null)
        {
            if (pageSize <= maxResultsCountPerPage)
            {
                finalPageSize = pageSize.Value;
                finalPageIndex = pageIndex ?? 0;
            }
            else
            {
                finalPageSize = maxResultsCountPerPage;
                if (pageIndex != null)
                {
                    var oldPagingDescriptor = filteredItems.Page(pageSize.Value);
                    var oldPageBoundries = oldPagingDescriptor.PagesBoundries[pageIndex.Value];
                    var targetedItemZeroIndex = oldPageBoundries.FirstItemZeroIndex;
                    var newPagingDescriptor = filteredItems.Page(finalPageSize);
                    finalPageIndex =
                        newPagingDescriptor
                            .PagesBoundries
                            .ToList()
                            .FindIndex(i => i.FirstItemZeroIndex <= targetedItemZeroIndex && i.LastItemZeroIndex >= targetedItemZeroIndex);
                }
            }
        }
        var pagingDescriptor = filteredItems.Page(finalPageSize);
        var pageBoundries = pagingDescriptor.PagesBoundries[finalPageIndex];
        var from = pageBoundries.FirstItemZeroIndex;
        var to = pageBoundries.LastItemZeroIndex;
        return new QueryResult<Character>(pagingDescriptor, finalPageIndex, filteredItems.Skip(from).Take(to - from + 1));
    }
}