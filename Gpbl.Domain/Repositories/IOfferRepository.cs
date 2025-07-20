using Gpbl.Domain.Models;

namespace Gpbl.Domain.Repositories;

public interface IOfferRepository
{
    Task<Offer> AddAsync(Offer offer);
    Task<Offer> GetByIdAsync(int id);
    IQueryable<Offer> GetAllAsQueryable();
}