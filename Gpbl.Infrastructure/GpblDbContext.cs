using Gpbl.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Gpbl.Infrastructure;

public class GpblDbContext(DbContextOptions<GpblDbContext> options) : DbContext(options)
{
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
}