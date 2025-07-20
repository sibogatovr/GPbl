using Gpbl.Application.Models;

namespace Gpbl.Application.Services.Suppliers;

public interface ISupplierService
{
    Task<List<PopularSupplierModel>> GetPopularSuppliersAsync(int topCount = 3);
    Task<List<PopularSupplierModel>> GetAllSuppliersAsync();
}