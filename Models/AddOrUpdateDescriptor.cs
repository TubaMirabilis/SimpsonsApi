using SimpsonsApi.Enums;
namespace SimpsonsApi.Models;
public class AddOrUpdateDescriptor : IAddOrUpdateDescriptor
{
    public AddOrUpdate ActionType { get; }
    public Guid Id { get; }

    public AddOrUpdateDescriptor(AddOrUpdate actionType, Guid id)
    {
        ActionType = actionType;
        Id = id;
    }
}