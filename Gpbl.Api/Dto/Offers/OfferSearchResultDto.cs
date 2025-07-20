namespace Gpbl.Api.Dto.Offers;

public class OfferSearchResultDto
{
    public int TotalCount { get; set; }
    public List<OfferDto> Offers { get; set; } = [];
}
