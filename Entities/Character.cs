namespace SimpsonsApi.Entities;
public class Character : Entity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Occupation { get; set; }
    public required DateTime CreatedAt { get; set; }
}