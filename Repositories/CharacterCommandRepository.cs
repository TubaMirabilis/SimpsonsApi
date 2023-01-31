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
    public override async Task Update(Character entity)
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
    public override async Task Update(IEnumerable<Character?> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);
        foreach (var character in entities)
        {
            ArgumentNullException.ThrowIfNull(character);
            await Update(character);
        }
    }
    public override async Task<IAddOrUpdateDescriptor> AddOrUpdate(Character? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var foundCharacter = await _ctx.Characters!.FirstOrDefaultAsync(c => c.Id == entity.Id);
        if (foundCharacter is not null)
        {
            await Update(entity);
            return new AddOrUpdateDescriptor(Enums.AddOrUpdate.Update, entity.Id);
        }
        return new AddOrUpdateDescriptor(Enums.AddOrUpdate.Add, Add(entity));
    }
    public override IEnumerable<Task<IAddOrUpdateDescriptor>> AddOrUpdate(IEnumerable<Character?> entities)
    {
        return entities.Select(AddOrUpdate).ToList();
    }
    public override async Task<bool> Delete(Guid id)
    {
        var foundCharacter = await _ctx.Characters!.FirstOrDefaultAsync(c => c.Id == id);
        if (foundCharacter is null)
        {
            return false;
        }
        _ctx.Characters?.Remove(foundCharacter);
        return true;
    }
    public override async Task<bool> Delete(Character? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        return await Delete(entity.Id);
    }
    public override IDictionary<Guid, Task<bool>> Delete(IEnumerable<Character?> entities)
    {
        return entities
            .Where(c => c is not null)
            .ToDictionary(c => c!.Id, Delete);
    }
    public async Task<bool> SaveChangesAsync()
    {
        if (await _ctx.SaveChangesAsync() > 0)
        {
            return true;
        }
        return false;
    }
}