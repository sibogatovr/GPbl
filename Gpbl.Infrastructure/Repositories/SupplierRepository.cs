using Gpbl.Domain.Models;
using Gpbl.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gpbl.Infrastructure.Repositories;

public class SupplierRepository(GpblDbContext dbContext) : ISupplierRepository
{
    public async Task<List<Supplier>> GetAllAsync() => await dbContext.Suppliers.ToListAsync();

    public async Task<Supplier?> GetByIdAsync(int id) => await dbContext.Suppliers.FindAsync(id);
}