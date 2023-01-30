using SimpsonsApi.Data;
using SimpsonsApi.Entities;
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
        // var newCharacter = new Character(entity, Guid.NewGuid());
        _ctx.Characters?.Add(entity);
        return entity.Id;
    }
    public override IEnumerable<Guid> Add(IEnumerable<Character?> entities)
    {
        return entities.Select(Add).ToList();
    }
    public override void Update(Character entity)
    {
        var foundCharacter = _ctx.Characters?.FirstOrDefault(c => c.Id == entity.Id);
        ArgumentNullException.ThrowIfNull(foundCharacter);
        _ctx.Characters?.Remove(foundCharacter);
        _ctx.Characters?.Add(entity);
    }
    public override void Update(IEnumerable<Character?> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);
        foreach (var character in entities)
        {
            ArgumentNullException.ThrowIfNull(character);
            Update(character);
        }
    }
    public override IAddOrUpdateDescriptor AddOrUpdate(Character? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var foundCharacter = _ctx.Characters?.FirstOrDefault(c => c.Id == entity.Id);
        if (foundCharacter is not null)
        {
            Update(entity);
            return new AddOrUpdateDescriptor(Enums.AddOrUpdate.Update, entity.Id);
        }
        return new AddOrUpdateDescriptor(Enums.AddOrUpdate.Add, Add(entity));
    }
    public override IEnumerable<IAddOrUpdateDescriptor> AddOrUpdate(IEnumerable<Character?> entities)
    {
        return entities.Select(AddOrUpdate).ToList();
    }
    public override bool Delete(Guid id)
    {
        var foundCharacter = _ctx.Characters?.FirstOrDefault(c => c.Id == id);
        if (foundCharacter is null)
        {
            return false;
        }
        _ctx.Characters?.Remove(foundCharacter);
        return true;
    }
    public override bool Delete(Character? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        return Delete(entity.Id);
    }
    public override IDictionary<Guid, bool> Delete(IEnumerable<Character?> entities)
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