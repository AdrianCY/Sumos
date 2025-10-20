using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sumos.Data.Models;

namespace Sumos.Data;

public class SumosDbContext(DbContextOptions<SumosDbContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Organization> Organizations { get; set; } = null!;
}