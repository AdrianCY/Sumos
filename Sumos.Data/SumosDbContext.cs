using Microsoft.EntityFrameworkCore;
using Sumos.Data.Models;

namespace Sumos.Data;

public class SumosDbContext(DbContextOptions<SumosDbContext> options) : DbContext(options)
{
    public DbSet<Organization> Organizations { get; set; } = null!;
}