using Microsoft.EntityFrameworkCore;
using TeslaDrive.Models;

namespace TeslaDrive.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
      
    }

    public DbSet<Car> Cars { get; set; }

    public DbSet<TeslaDrive.Models.PalmaAirport> PalmaAirport { get; set; } = default!;

    public DbSet<TeslaDrive.Models.PalmaCity> PalmaCity { get; set; } = default!;

    public DbSet<TeslaDrive.Models.Alcudia> Alcudia { get; set; } = default!;

    }
}
