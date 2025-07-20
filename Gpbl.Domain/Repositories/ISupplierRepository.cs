using Gpbl.Domain.Models;

namespace Gpbl.Domain.Repositories;

public interface ISupplierRepository
{
    Task<List<Supplier>> GetAllAsync();
    Task<Supplier?> GetByIdAsync(int id);
}