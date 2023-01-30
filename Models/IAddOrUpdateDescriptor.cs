using SimpsonsApi.Enums;
namespace SimpsonsApi.Models;
public interface IAddOrUpdateDescriptor
{
    AddOrUpdate ActionType { get; }
    Guid Id { get; }
}