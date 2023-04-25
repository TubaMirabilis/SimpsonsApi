using Microsoft.EntityFrameworkCore;
using SimpsonsApi.Entities;
namespace SimpsonsApi.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Character>? Characters { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Character>().HasData(GenerateCharacters());
    }
    IEnumerable<Character> GenerateCharacters()
    {
        yield return new Character
        {
            Id = Guid.NewGuid(),
            Name = "Dewey Largo",
            Occupation = "Music Teacher",
            CreatedAt = DateTime.UtcNow,
            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/b/b6/Dewey_Largo_Tapped_Out.png/revision/latest?cb=20201225173139"
        };
        yield return new Character
        {
            Id = Guid.NewGuid(),
            Name = "Eddie",
            Occupation = "Police Officer",
            CreatedAt = DateTime.UtcNow,
            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/c/c3/Eddie.png/revision/latest?cb=20201222215954"
        };
        yield return new Character
        {
            Id = Guid.NewGuid(),
            Name = "Janey Powell",
            Occupation = "Schoolgirl",
            CreatedAt = DateTime.UtcNow,
            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/3/36/Janey_Tapped_Out.png/revision/latest?cb=20141218000819"
        };
        yield return new Character
        {
            Id = Guid.NewGuid(),
            Name = "Jasper Beardly",
            Occupation = "Retiree",
            CreatedAt = DateTime.UtcNow,
            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/d/da/Jasper_Beardsley.png/revision/latest?cb=20201222215930"
        };
        yield return new Character
        {
            Id = Guid.NewGuid(),
            Name = "Kent Brockman",
            Occupation = "News Anchor",
            CreatedAt = DateTime.UtcNow,
            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/0/0d/Kent_Brockman_-_shading.png/revision/latest?cb=20201222215914"
        };
        yield return new Character
        {
            Id = Guid.NewGuid(),
            Name = "Herschel Shmoikel Pinchas Yerucham Krustofsky",
            Occupation = "TV Entertainer",
            CreatedAt = DateTime.UtcNow,
            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/0/07/Tapped_Out_Unlock_Krusty.png/revision/latest?cb=20141120143301"
        };
        yield return new Character
        {
            Id = Guid.NewGuid(),
            Name = "Lenny Leonard",
            Occupation = "Nuclear Power Technician",
            CreatedAt = DateTime.UtcNow,
            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/a/ae/Lenny_Leonard.png/revision/latest?cb=20201222215907"
        };
    }
}