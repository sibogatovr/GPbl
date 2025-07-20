namespace Gpbl.Application.Models;

public class CreateOffer
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int SupplierId { get; set; }
    public DateTime RegistrationDate { get; set; }
}