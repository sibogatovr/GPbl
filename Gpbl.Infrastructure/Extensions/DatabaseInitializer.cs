using Gpbl.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Gpbl.Infrastructure.Extensions;

public static class DatabaseInitializer
{
    public static async Task InitializeDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<GpblDbContext>();
        
        await db.Database.MigrateAsync();
        
        await SeedSuppliersAsync(db);
        await SeedOffersAsync(db);
    }

    private static async Task SeedSuppliersAsync(GpblDbContext db)
    {
        if (await db.Suppliers.AnyAsync()) 
            return;

        var suppliers = new List<Supplier>
        {
            new() { Name = "Global Motors", CreatedAt = DateTime.UtcNow },
            new() { Name = "Auto Trade", CreatedAt = DateTime.UtcNow },
            new() { Name = "Carwow", CreatedAt = DateTime.UtcNow },
            new() { Name = "Encar", CreatedAt = DateTime.UtcNow },
            new() { Name = "Express Auto", CreatedAt = DateTime.UtcNow }
        };
        
        await db.Suppliers.AddRangeAsync(suppliers);
        await db.SaveChangesAsync();
    }

    private static async Task SeedOffersAsync(GpblDbContext db)
    {
        if (await db.Offers.AnyAsync()) 
            return;

        var suppliers = await db.Suppliers.ToListAsync();
        var offersData = new List<(string Brand, string Model)>
        {
            ("Mercedes", "C180"),
            ("Mercedes", "C63"),
            ("Mercedes", "G63"),
            ("Mercedes", "Sprinter"),
            ("Mercedes", "V"),
            ("Mercedes", "S-class MAYBACH"),
            ("Audi", "RS6"),
            ("Audi", "RSQ8"),
            ("Audi", "RS7"),
            ("Toyota", "Camry"),
            ("Toyota", "Land Cruiser 200"),
            ("Porsche", "Panamera"),
            ("Volkswagen", "Passat CC"),
            ("Volkswagen", "Tiguan"),
            ("Volkswagen", "Touareg")
        };

        var rnd = new Random();
        var offers = offersData
            .Select(data => new Offer
        {
            Brand = data.Brand,
            Model = data.Model,
            SupplierId = suppliers[rnd.Next(suppliers.Count)].Id,
            RegistrationDate = DateTime.Now.AddDays(-rnd.Next(1, 100))
        })
            .ToList();

        await db.Offers.AddRangeAsync(offers);
        await db.SaveChangesAsync();
    }
} 