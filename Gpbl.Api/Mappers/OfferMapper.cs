using Gpbl.Api.Dto.Offers;
using Gpbl.Application.Models;
using Gpbl.Domain.Models;

namespace Gpbl.Api.Mappers;

public static class OfferMapper
{
    public static CreateOffer ToAppModel(this CreateOfferDto dto)
    {
        return new CreateOffer
        {
            Brand = dto.Brand,
            Model = dto.Model,
            SupplierId = dto.SupplierId,
            RegistrationDate = dto.RegistrationDate
        };
    }
    
    public static OfferDto ToDto(this Offer domain)
    {
        return new OfferDto
        {
            Id = domain.Id,
            Brand = domain.Brand,
            Model = domain.Model,
            RegistrationDate = domain.RegistrationDate,
            Supplier = domain.Supplier.ToDto()
        };
    }
}