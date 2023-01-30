using SimpsonsApi.Entities;
using SimpsonsApi.Models;

namespace SimpsonsApi.Repositories;
public interface ICommandRepository
{
    Guid Add(Entity entity);
    IEnumerable<Guid> Add(IEnumerable<Entity> entities);
    void Update(Entity entity);
    void Update(IEnumerable<Entity> entities);
    IAddOrUpdateDescriptor AddOrUpdate(Entity entity);
    IEnumerable<IAddOrUpdateDescriptor> AddOrUpdate(IEnumerable<Entity> entities);
    bool Delete(Guid id);
    bool Delete(Entity entity);
    IDictionary<Guid, bool> Delete(IEnumerable<Entity> entities);
}
public interface ICommandRepository<in TEntity> : ICommandRepository where TEntity : Entity
{
    Guid Add(TEntity entity);
    IEnumerable<Guid> Add(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Update(IEnumerable<TEntity> entities);
    IAddOrUpdateDescriptor AddOrUpdate(TEntity entity);
    IEnumerable<IAddOrUpdateDescriptor> AddOrUpdate(IEnumerable<TEntity> entities);
    bool Delete(TEntity entity);
    IDictionary<Guid, bool> Delete(IEnumerable<TEntity> entities);
    abstract Guid ICommandRepository.Add(Entity entity);
    abstract IEnumerable<Guid> ICommandRepository.Add(IEnumerable<Entity> entities);
    abstract void ICommandRepository.Update(Entity entity);
    abstract void ICommandRepository.Update(IEnumerable<Entity> entities);
    abstract IAddOrUpdateDescriptor ICommandRepository.AddOrUpdate(Entity entity);
    abstract IEnumerable<IAddOrUpdateDescriptor> ICommandRepository.AddOrUpdate(IEnumerable<Entity> entities);
    abstract bool ICommandRepository.Delete(Entity entity);
    abstract IDictionary<Guid, bool> ICommandRepository.Delete(IEnumerable<Entity> entities);
}