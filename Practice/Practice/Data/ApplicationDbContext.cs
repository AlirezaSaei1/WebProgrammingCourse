using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category>? Categories { set; get; }
}