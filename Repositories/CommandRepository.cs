using SimpsonsApi.Entities;
using SimpsonsApi.Models;
namespace SimpsonsApi.Repositories;
public abstract class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : Entity
{
    public abstract Task<bool> Delete(Guid id);
    public abstract Guid Add(TEntity entity);
    public abstract IEnumerable<Guid> Add(IEnumerable<TEntity?> entities);
    public abstract Task Update(TEntity entity);
    public abstract Task Update(IEnumerable<TEntity?> entities);
    public abstract Task<IAddOrUpdateDescriptor> AddOrUpdate(TEntity entity);
    public abstract IEnumerable<Task<IAddOrUpdateDescriptor>> AddOrUpdate(IEnumerable<TEntity?> entities);
    public abstract Task<bool> Delete(TEntity entity);
    public abstract IDictionary<Guid, Task<bool>> Delete(IEnumerable<TEntity?> entities);
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
    async Task ICommandRepository.Update(Entity entity)
    {
        var x = entity as TEntity;
        ArgumentNullException.ThrowIfNull(x);
        if (entity.GetType() == typeof(TEntity))
        {
            await Update(x);
        }
        else
        {
            throw new ArgumentException(
                $"The type \"{entity.GetType()}\" does not match the type \"{typeof(TEntity)}\"");
        }
    }
    async Task ICommandRepository.Update(IEnumerable<Entity> entities)
    {
        if (entities is IEnumerable<TEntity>)
        {
            await Update(entities.Select(e => e as TEntity));
        }
        else
        {
            throw new ArgumentException(
                $"The type \"{entities.GetType()}\" does not match the type \"{typeof(IEnumerable<TEntity>)}\"");
        }
    }
    async Task<IAddOrUpdateDescriptor> ICommandRepository.AddOrUpdate(Entity entity)
    {
        var x = entity as TEntity;
        ArgumentNullException.ThrowIfNull(x);
        if (entity.GetType() == typeof(TEntity))
        {
            return await AddOrUpdate(x);
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
    async Task<bool> ICommandRepository.Delete(Entity entity)
    {
        var x = entity as TEntity;
        ArgumentNullException.ThrowIfNull(x);
        if (entity.GetType() == typeof(TEntity))
        {
            return await Delete(x);
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