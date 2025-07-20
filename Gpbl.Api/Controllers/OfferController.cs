using Gpbl.Api.Dto.Offers;
using Gpbl.Api.Mappers;
using Gpbl.Application.Services.Offers;
using Microsoft.AspNetCore.Mvc;

namespace Gpbl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfferController(IOfferService offerService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOffer([FromBody] CreateOfferDto dto)
    {
        var createOfferResult = await offerService.CreateAsync(dto.ToAppModel());
        return CreatedAtAction(nameof(GetOfferById), new { id = createOfferResult.Id }, createOfferResult);
    }

    [HttpGet]
    public async Task<ActionResult<OfferSearchResultDto>> SearchOffers([FromQuery] string? brand,
        [FromQuery] string? model, [FromQuery] int? supplierId)
    {
        var result = await offerService.SearchOffersAsync(brand, model, supplierId);
        return new OfferSearchResultDto
        {
            TotalCount = result.TotalCount, 
            Offers = result.Offers
                .Select(o => o.ToDto())
                .ToList()
        };
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOfferById(int id)
    {
        var offer = await offerService.GetByIdAsync(id);
        return Ok(offer);
    }
}