namespace core_web_api.Data;

using core_web_api.Models;
using Microsoft.EntityFrameworkCore;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<SuperHero> SuperHeroes { get; set; }
}