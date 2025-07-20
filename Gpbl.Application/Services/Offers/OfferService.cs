using Gpbl.Application.Models;
using Gpbl.Domain.Models;
using Gpbl.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gpbl.Application.Services.Offers;

public class OfferService(IOfferRepository offerRepository) : IOfferService
{
    public async Task<Offer> CreateAsync(CreateOffer createOffer)
    {
        var offer = new Offer
        {
            Brand = createOffer.Brand,
            Model = createOffer.Model,
            SupplierId = createOffer.SupplierId,
            RegistrationDate = createOffer.RegistrationDate
        };
        
        return await offerRepository.AddAsync(offer);
    }

    public async Task<Offer> GetByIdAsync(int offerId)
    {
        return await offerRepository.GetByIdAsync(offerId);
    }
    
    public async Task<OfferSearchResultModel> SearchOffersAsync(string? brand, string? model, int? supplierId)
    {
        var query = offerRepository.GetAllAsQueryable();

        if (!string.IsNullOrEmpty(brand))
            query = query.Where(o => o.Brand.Contains(brand));
        if (!string.IsNullOrEmpty(model))
            query = query.Where(o => o.Model.Contains(model));
        if (supplierId.HasValue)
            query = query.Where(o => o.SupplierId == supplierId);

        var totalCount = await query.CountAsync();

        var offers = await query
            .Select(o => new Offer
            {
                Id = o.Id,
                Brand = o.Brand,
                Model = o.Model,
                RegistrationDate = o.RegistrationDate,
                Supplier = new Supplier
                {
                    Id = o.Supplier.Id,
                    Name = o.Supplier.Name
                }
            })
            .ToListAsync();

        return new OfferSearchResultModel { TotalCount = totalCount, Offers = offers };
    }
    
    public IQueryable<Offer> GetAllAsQueryable() => offerRepository.GetAllAsQueryable();
    
    
    
}