namespace SimpsonsApi.Entities;
public class Character : Entity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Occupation { get; set; }

    // public Character(Guid id, string name, string occupation)
    // {
    //     Id = id;
    //     Name = name;
    //     Occupation = occupation;
    // }

    // public Character(Character other, Guid id)
    // {
    //     ArgumentNullException.ThrowIfNull(other);
    //     Id = id;
    //     Name = other.Name;
    //     Occupation = other.Occupation;
    // }
}