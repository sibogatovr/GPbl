using Gpbl.Api.Dto.Suppliers;
using Gpbl.Domain.Models;

namespace Gpbl.Api.Mappers;

public static class SupplierMapper
{
    public static SupplierDto ToDto(this Supplier domain)
    {
        return new SupplierDto
        {
            Id = domain.Id,
            Name = domain.Name
        };
    }
}