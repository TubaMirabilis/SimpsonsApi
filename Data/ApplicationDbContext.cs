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
}