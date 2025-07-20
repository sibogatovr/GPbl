using Gpbl.Api.Dto.Suppliers;

namespace Gpbl.Api.Dto.Offers;

public class OfferDto
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public DateTime RegistrationDate { get; set; }
    public SupplierDto Supplier { get; set; }
}