using SimpsonsApi.Entities;
using SimpsonsApi.Models;
namespace SimpsonsApi.Repositories;
public abstract class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : Entity
{
    public abstract bool Delete(Guid id);
    public abstract Guid Add(TEntity entity);
    public abstract IEnumerable<Guid> Add(IEnumerable<TEntity?> entities);
    public abstract void Update(TEntity entity);
    public abstract void Update(IEnumerable<TEntity?> entities);
    public abstract IAddOrUpdateDescriptor AddOrUpdate(TEntity entity);
    public abstract IEnumerable<IAddOrUpdateDescriptor> AddOrUpdate(IEnumerable<TEntity?> entities);
    public abstract bool Delete(TEntity entity);
    public abstract IDictionary<Guid, bool> Delete(IEnumerable<TEntity?> entities);
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
    void ICommandRepository.Update(Entity entity)
    {
        var x = entity as TEntity;
        ArgumentNullException.ThrowIfNull(x);
        if (entity.GetType() == typeof(TEntity))
        {
            Update(x);
        }
        else
        {
            throw new ArgumentException(
                $"The type \"{entity.GetType()}\" does not match the type \"{typeof(TEntity)}\"");
        }
    }
    void ICommandRepository.Update(IEnumerable<Entity> entities)
    {
        if (entities is IEnumerable<TEntity>)
        {
            Update(entities.Select(e => e as TEntity));
        }
        else
        {
            throw new ArgumentException(
                $"The type \"{entities.GetType()}\" does not match the type \"{typeof(IEnumerable<TEntity>)}\"");
        }
    }
    IAddOrUpdateDescriptor ICommandRepository.AddOrUpdate(Entity entity)
    {
        var x = entity as TEntity;
        ArgumentNullException.ThrowIfNull(x);
        if (entity.GetType() == typeof(TEntity))
        {
            return AddOrUpdate(x);
        }
        throw new ArgumentException(
            $"The type \"{entity.GetType()}\" does not match the type \"{typeof(TEntity)}\"");
    }
    IEnumerable<IAddOrUpdateDescriptor> ICommandRepository.AddOrUpdate(IEnumerable<Entity> entities)
    {
        if (entities is IEnumerable<TEntity>)
        {
            return AddOrUpdate(entities.Select(e => e as TEntity));
        }
        throw new ArgumentException(
            $"The type \"{entities.GetType()}\" does not match the type \"{typeof(IEnumerable<TEntity>)}\"");
    }
    bool ICommandRepository.Delete(Entity entity)
    {
        var x = entity as TEntity;
        ArgumentNullException.ThrowIfNull(x);
        if (entity.GetType() == typeof(TEntity))
        {
            return Delete(x);
        }
        throw new ArgumentException(
            $"The type \"{entity.GetType()}\" does not match the type \"{typeof(TEntity)}\"");
    }
    IDictionary<Guid, bool> ICommandRepository.Delete(IEnumerable<Entity> entities)
    {
        if (entities is IEnumerable<TEntity>)
        {
            return Delete(entities.Select(e => e as TEntity));
        }
        throw new ArgumentException(
            $"The type \"{entities.GetType()}\" does not match the type \"{typeof(IEnumerable<TEntity>)}\"");
    }
}