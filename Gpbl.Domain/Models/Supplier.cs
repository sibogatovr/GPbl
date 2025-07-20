namespace Gpbl.Domain.Models;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Offer> Offers { get; set; }
}