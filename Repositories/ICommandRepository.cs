using SimpsonsApi.Entities;
using SimpsonsApi.Models;

namespace SimpsonsApi.Repositories;
public interface ICommandRepository
{
    Guid Add(Entity entity);
    IEnumerable<Guid> Add(IEnumerable<Entity> entities);
    Task UpdateAsync(Entity entity);
    Task UpdateAsync(IEnumerable<Entity> entities);
    Task<IAddOrUpdateDescriptor> AddOrUpdateAsync(Entity entity);
    IEnumerable<Task<IAddOrUpdateDescriptor>> AddOrUpdate(IEnumerable<Entity> entities);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> DeleteAsync(Entity entity);
    IDictionary<Guid, Task<bool>> Delete(IEnumerable<Entity> entities);
}
public interface ICommandRepository<in TEntity> : ICommandRepository where TEntity : Entity
{
    Guid Add(TEntity entity);
    IEnumerable<Guid> Add(IEnumerable<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task UpdateAsync(IEnumerable<TEntity> entities);
    Task<IAddOrUpdateDescriptor> AddOrUpdateAsync(TEntity entity);
    IEnumerable<Task<IAddOrUpdateDescriptor>> AddOrUpdate(IEnumerable<TEntity> entities);
    Task<bool> DeleteAsync(TEntity entity);
    IDictionary<Guid, Task<bool>> Delete(IEnumerable<TEntity> entities);
    abstract Guid ICommandRepository.Add(Entity entity);
    abstract IEnumerable<Guid> ICommandRepository.Add(IEnumerable<Entity> entities);
    abstract Task ICommandRepository.UpdateAsync(Entity entity);
    abstract Task ICommandRepository.UpdateAsync(IEnumerable<Entity> entities);
    abstract Task<IAddOrUpdateDescriptor> ICommandRepository.AddOrUpdateAsync(Entity entity);
    abstract IEnumerable<Task<IAddOrUpdateDescriptor>> ICommandRepository.AddOrUpdate(IEnumerable<Entity> entities);
    abstract Task<bool> ICommandRepository.DeleteAsync(Entity entity);
    abstract IDictionary<Guid, Task<bool>> ICommandRepository.Delete(IEnumerable<Entity> entities);
}