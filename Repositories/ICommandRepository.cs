using SimpsonsApi.Entities;
using SimpsonsApi.Models;

namespace SimpsonsApi.Repositories;
public interface ICommandRepository
{
    Guid Add(Entity entity);
    IEnumerable<Guid> Add(IEnumerable<Entity> entities);
    Task Update(Entity entity);
    Task Update(IEnumerable<Entity> entities);
    Task<IAddOrUpdateDescriptor> AddOrUpdate(Entity entity);
    IEnumerable<Task<IAddOrUpdateDescriptor>> AddOrUpdate(IEnumerable<Entity> entities);
    Task<bool> Delete(Guid id);
    Task<bool> Delete(Entity entity);
    IDictionary<Guid, Task<bool>> Delete(IEnumerable<Entity> entities);
}
public interface ICommandRepository<in TEntity> : ICommandRepository where TEntity : Entity
{
    Guid Add(TEntity entity);
    IEnumerable<Guid> Add(IEnumerable<TEntity> entities);
    Task Update(TEntity entity);
    Task Update(IEnumerable<TEntity> entities);
    Task<IAddOrUpdateDescriptor> AddOrUpdate(TEntity entity);
    IEnumerable<Task<IAddOrUpdateDescriptor>> AddOrUpdate(IEnumerable<TEntity> entities);
    Task<bool> Delete(TEntity entity);
    IDictionary<Guid, Task<bool>> Delete(IEnumerable<TEntity> entities);
    abstract Guid ICommandRepository.Add(Entity entity);
    abstract IEnumerable<Guid> ICommandRepository.Add(IEnumerable<Entity> entities);
    abstract Task ICommandRepository.Update(Entity entity);
    abstract Task ICommandRepository.Update(IEnumerable<Entity> entities);
    abstract Task<IAddOrUpdateDescriptor> ICommandRepository.AddOrUpdate(Entity entity);
    abstract IEnumerable<Task<IAddOrUpdateDescriptor>> ICommandRepository.AddOrUpdate(IEnumerable<Entity> entities);
    abstract Task<bool> ICommandRepository.Delete(Entity entity);
    abstract IDictionary<Guid, Task<bool>> ICommandRepository.Delete(IEnumerable<Entity> entities);
}