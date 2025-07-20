using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Gpbl.Infrastructure;

public class GpblDbContextFactory : IDesignTimeDbContextFactory<GpblDbContext>
{
    public GpblDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GpblDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=GpblDb;User Id=sa;Password=1qaz@WSX;TrustServerCertificate=True");
        return new GpblDbContext(optionsBuilder.Options);
    }
}