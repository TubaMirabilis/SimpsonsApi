using SimpsonsApi.Entities;
using SimpsonsApi.Models;
namespace SimpsonsApi.Repositories;
public abstract class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : Entity
{
    public abstract Task<bool> DeleteAsync(Guid id);
    public abstract Guid Add(TEntity entity);
    public abstract IEnumerable<Guid> Add(IEnumerable<TEntity?> entities);
    public abstract Task UpdateAsync(TEntity entity);
    public abstract Task UpdateAsync(IEnumerable<TEntity?> entities);
    public abstract Task<IAddOrUpdateDescriptor> AddOrUpdateAsync(TEntity entity);
    public abstract IEnumerable<Task<IAddOrUpdateDescriptor>> AddOrUpdate(IEnumerable<TEntity?> entities);
    public abstract Task<bool> DeleteAsync(TEntity entity);
    public abstract IDictionary<Guid, Task<bool>> Delete(IEnumerable<TEntity?> entities);
    public abstract Task<bool> SaveChangesAsync();
    Guid ICommandRepository.Add(Entity entity)
    {
        var x = entity as TEntity;
        ArgumentNullException.ThrowIfNull(x);
        if (entity.GetType() == typeof(TEntity))
        {
            return Add(x);
        }
        throw new ArgumentException(
            $"The type \"{entity.GetType()}\" does not match the type \"{typeof(TEntity)}\"");
    }
    IEnumerable<Guid> ICommandRepository.Add(IEnumerable<Entity> entities)
    {
        if (entities is IEnumerable<TEntity>)
        {
            return Add(entities.Select(e => e as TEntity));
        }
        throw new ArgumentException(
            $"The type \"{entities.GetType()}\" does not match the type \"{typeof(IEnumerable<TEntity>)}\"");
    }
    async Task ICommandRepository.UpdateAsync(Entity entity)
    {
        var x = entity as TEntity;
        ArgumentNullException.ThrowIfNull(x);
        if (entity.GetType() == typeof(TEntity))
        {
            await UpdateAsync(x);
        }
        else
        {
            throw new ArgumentException(
                $"The type \"{entity.GetType()}\" does not match the type \"{typeof(TEntity)}\"");
        }
    }
    async Task ICommandRepository.UpdateAsync(IEnumerable<Entity> entities)
    {
        if (entities is IEnumerable<TEntity>)
        {
            await UpdateAsync(entities.Select(e => e as TEntity));
        }
        else
        {
            throw new ArgumentException(
                $"The type \"{entities.GetType()}\" does not match the type \"{typeof(IEnumerable<TEntity>)}\"");
        }
    }
    async Task<IAddOrUpdateDescriptor> ICommandRepository.AddOrUpdateAsync(Entity entity)
    {
        var x = entity as TEntity;
        ArgumentNullException.ThrowIfNull(x);
        if (entity.GetType() == typeof(TEntity))
        {
            return await AddOrUpdateAsync(x);
        }
        throw new ArgumentException(
            $"The type \"{entity.GetType()}\" does not match the type \"{typeof(TEntity)}\"");
    }
    IEnumerable<Task<IAddOrUpdateDescriptor>> ICommandRepository.AddOrUpdate(IEnumerable<Entity> entities)
    {
        if (entities is IEnumerable<TEntity>)
        {
            return AddOrUpdate(entities.Select(e => e as TEntity));
        }
        throw new ArgumentException(
            $"The type \"{entities.GetType()}\" does not match the type \"{typeof(IEnumerable<TEntity>)}\"");
    }
    async Task<bool> ICommandRepository.DeleteAsync(Entity entity)
    {
        var x = entity as TEntity;
        ArgumentNullException.ThrowIfNull(x);
        if (entity.GetType() == typeof(TEntity))
        {
            return await DeleteAsync(x);
        }
        throw new ArgumentException(
            $"The type \"{entity.GetType()}\" does not match the type \"{typeof(TEntity)}\"");
    }
    IDictionary<Guid, Task<bool>> ICommandRepository.Delete(IEnumerable<Entity> entities)
    {
        if (entities is IEnumerable<TEntity>)
        {
            return Delete(entities.Select(e => e as TEntity));
        }
        throw new ArgumentException(
            $"The type \"{entities.GetType()}\" does not match the type \"{typeof(IEnumerable<TEntity>)}\"");
    }
}