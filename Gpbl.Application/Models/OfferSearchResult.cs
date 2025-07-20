using Gpbl.Domain.Models;

namespace Gpbl.Application.Models;

public class OfferSearchResultModel
{
    public int TotalCount { get; set; }
    public List<Offer> Offers { get; set; } = new();
}