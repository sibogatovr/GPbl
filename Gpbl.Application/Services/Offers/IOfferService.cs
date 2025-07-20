using Gpbl.Application.Models;
using Gpbl.Domain.Models;

namespace Gpbl.Application.Services.Offers;

public interface IOfferService
{
    Task<Offer> CreateAsync(CreateOffer createOfferDto);
    Task<Offer> GetByIdAsync(int offerId);
    IQueryable<Offer> GetAllAsQueryable();
    Task<OfferSearchResultModel> SearchOffersAsync(string? brand, string? model, int? supplierId);
}