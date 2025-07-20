using Gpbl.Domain.Models;
using Gpbl.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gpbl.Infrastructure.Repositories;

public class OfferRepository(
    GpblDbContext context,
    ISupplierRepository supplierRepository) : IOfferRepository
{
    public async Task<Offer> AddAsync(Offer offer)
    {
        var supplier = await supplierRepository.GetByIdAsync(offer.SupplierId);
        if (supplier is null)
            throw new ArgumentException($"Supplier with id: {offer.SupplierId} does not exist.");
        
        offer.Supplier = supplier;
        context.Offers.Add(offer);
        await context.SaveChangesAsync();
        return offer;
    }

    public async Task<Offer> GetByIdAsync(int id)
    {
        var offer = await context.Offers
            .Include(x=>x.Supplier)
            .FirstOrDefaultAsync(x=>x.Id == id);
        
        if (offer is null)
            throw new ArgumentException($"Offer with id: {id} does not exist.");
        return offer;
    }

    public IQueryable<Offer> GetAllAsQueryable() => 
        context.Offers.Include(x=>x.Supplier).AsNoTracking();
}