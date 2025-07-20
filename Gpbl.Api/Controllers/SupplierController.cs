using Gpbl.Api.Dto.Suppliers;
using Gpbl.Application.Services.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace Gpbl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupplierController(ISupplierService supplierService) : ControllerBase
{
    [HttpGet("popular")]
    public async Task<ActionResult<List<PopularSupplierDto>>> GetPopularSuppliers()
    {
        var result = await supplierService.GetPopularSuppliersAsync();
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<PopularSupplierDto>>> GetAllSuppliers()
    {
        var result = await supplierService.GetAllSuppliersAsync();
        return Ok(result);
    }
} 