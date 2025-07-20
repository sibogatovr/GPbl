using Gpbl.Application.Models;
using Gpbl.Application.Services.Offers;
using Gpbl.Domain.Repositories;

namespace Gpbl.Application.Services.Suppliers;

public class SupplierService(IOfferService offerService, ISupplierRepository supplierRepository) : ISupplierService
{
    public async Task<List<PopularSupplierModel>> GetPopularSuppliersAsync(int topCount = 3)
    {
        var offers = offerService.GetAllAsQueryable();
        var popular = offers
            .GroupBy(o => new { o.SupplierId, o.Supplier.Name })
            .Select(g => new PopularSupplierModel
            {
                Id = g.Key.SupplierId,
                Name = g.Key.Name,
                OffersCount = g.Count()
            })
            .OrderByDescending(x => x.OffersCount)
            .Take(topCount)
            .ToList();

        return popular;
    }

    public async Task<List<PopularSupplierModel>> GetAllSuppliersAsync()
    {
        var suppliers = await supplierRepository.GetAllAsync();
        return suppliers.Select(s => new PopularSupplierModel
        {
            Id = s.Id,
            Name = s.Name,
            OffersCount = 0
        }).ToList();
    }
}