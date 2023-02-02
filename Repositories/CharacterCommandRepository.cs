using Microsoft.EntityFrameworkCore;
using SimpsonsApi.Data;
using SimpsonsApi.Entities;
using SimpsonsApi.Exceptions;
using SimpsonsApi.Models;
namespace SimpsonsApi.Repositories;
public class CharacterCommandRepository : CommandRepository<Character>
{
    private readonly ApplicationDbContext _ctx;
    public CharacterCommandRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }
    public override Guid Add(Character? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        entity.CreatedAt = DateTime.UtcNow;
        _ctx.Characters?.Add(entity);
        return entity.Id;
    }
    public override IEnumerable<Guid> Add(IEnumerable<Character?> entities)
    {
        return entities.Select(Add).ToList();
    }
    public override async Task UpdateAsync(Character entity)
    {
        var foundCharacter = await _ctx.Characters!.FirstOrDefaultAsync(c => c.Id == entity.Id);
        ArgumentNullException.ThrowIfNull(foundCharacter);
        if (entity.CreatedAt != foundCharacter.CreatedAt)
        {
            throw new PropertyValueMismatchException(nameof(entity.CreatedAt));
        }
        _ctx.Characters?.Remove(foundCharacter);
        _ctx.Characters?.Add(entity);
    }
    public override async Task UpdateAsync(IEnumerable<Character?> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);
        foreach (var character in entities)
        {
            ArgumentNullException.ThrowIfNull(character);
            await UpdateAsync(character);
        }
    }
    public override async Task<IAddOrUpdateDescriptor> AddOrUpdateAsync(Character? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var foundCharacter = await _ctx.Characters!.FirstOrDefaultAsync(c => c.Id == entity.Id);
        if (foundCharacter is not null)
        {
            await UpdateAsync(entity);
            return new AddOrUpdateDescriptor(Enums.AddOrUpdate.Update, entity.Id);
        }
        return new AddOrUpdateDescriptor(Enums.AddOrUpdate.Add, Add(entity));
    }
    public override IEnumerable<Task<IAddOrUpdateDescriptor>> AddOrUpdate(IEnumerable<Character?> entities)
    {
        return entities.Select(AddOrUpdateAsync).ToList();
    }
    public override async Task<bool> DeleteAsync(Guid id)
    {
        var foundCharacter = await _ctx.Characters!.FirstOrDefaultAsync(c => c.Id == id);
        if (foundCharacter is null)
        {
            return false;
        }
        _ctx.Characters?.Remove(foundCharacter);
        return true;
    }
    public override async Task<bool> DeleteAsync(Character? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        return await DeleteAsync(entity.Id);
    }
    public override IDictionary<Guid, Task<bool>> Delete(IEnumerable<Character?> entities)
    {
        return entities
            .Where(c => c is not null)
            .ToDictionary(c => c!.Id, DeleteAsync);
    }
    public override async Task<bool> SaveChangesAsync()
    {
        if (await _ctx.SaveChangesAsync() > 0)
        {
            return true;
        }
        return false;
    }
}