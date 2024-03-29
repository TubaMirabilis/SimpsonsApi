﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SimpsonsApi.Data;
using SimpsonsApi.Entities;
using SimpsonsApi.Exceptions;
using SimpsonsApi.Extensions;
using SimpsonsApi.Models;
namespace SimpsonsApi.Repositories;
public class CharacterQueryRepository : QueryRepository<Character>
{
    private readonly int maxResultsCountPerPage = 24;
    private readonly ApplicationDbContext _ctx;
    public CharacterQueryRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }
    public override async Task<IQueryResult<Character>> GetAllAsync()
    {
        return await GetAsync(c => true, null, null);
    }
    public override async Task<Character> GetAsync(Guid id)
    {
        var c = await _ctx.Characters!.FirstOrDefaultAsync(c => c.Id == id);
        ArgumentNullException.ThrowIfNull(c);
        return c;
    }
    public override async Task<IQueryResult<Character>> GetAsync(int pageSize, int pageIndex)
    {
        return await GetAsync(c => true, pageSize, pageIndex);
    }
    public override async Task<IQueryResult<Character>> GetByExpressionAsync(Expression<Func<Character, bool>> predicate)
    {
        return await GetAsync(predicate, null, null);
    }
    public override async Task<IQueryResult<Character>> GetByExpressionAsync(Expression<Func<Character, bool>> predicate, int pageSize, int pageIndex)
    {
        return await GetAsync(predicate, pageSize, pageIndex);
    }
    private async Task<IQueryResult<Character>> GetAsync(Expression<Func<Character, bool>> predicate, int? pageSize, int? pageIndex)
    {
        if (pageSize <= 0)
        {
            throw new IndexOutOfRangeException("Page size must be greater than zero");
        }
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
        if (filteredItems.Count == 0)
        {
            throw new CollectionEmptyException();
        }
        var pagingDescriptor = filteredItems.Page(finalPageSize);
        if (pageIndex >= pagingDescriptor.NumberOfPages)
        {
            throw new IndexOutOfRangeException($"Page index cannot be greater than {pagingDescriptor.NumberOfPages - 1}");
        }
        var pageBoundries = pagingDescriptor.PagesBoundries[finalPageIndex];
        var from = pageBoundries.FirstItemZeroIndex;
        var to = pageBoundries.LastItemZeroIndex;
        return new QueryResult<Character>(pagingDescriptor, finalPageIndex, filteredItems.Skip(from).Take(to - from + 1));
    }
}