using Gpbl.Application.Services.Offers;
using Gpbl.Application.Services.Suppliers;
using Gpbl.Domain.Repositories;
using Gpbl.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Gpbl.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IOfferRepository, OfferRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IOfferService, OfferService>();
        services.AddScoped<ISupplierService, SupplierService>();
    }

    public static void AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<GpblDbContext>(options =>
            options.UseSqlServer(connectionString));
    }
} 