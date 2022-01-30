#nullable disable
using DataPapi.Entities;
using DataPapi.Helpers;
using DataPapi.Models;
using DataPapi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataPapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimProductsController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public DimProductsController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/DimProducts
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DimProduct>>> GetDimProducts()
        {
            // get user from context, previously stored when generating jwt token
            var user = (User)HttpContext.Items["User"];
            return await _context.DimProducts.Where(x => x.Manufacturer == user.CustomerId).ToListAsync();
        }

        // GET: api/DimProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DimProduct>> GetDimProduct(int id)
        {
            var dimProduct = await _context.DimProducts.FindAsync(id);

            if (dimProduct == null)
            {
                return NotFound();
            }

            return dimProduct;
        }

        // PUT: api/DimProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDimProduct(int id, DimProduct dimProduct)
        {
            if (id != dimProduct.ProductKey)
            {
                return BadRequest();
            }

            _context.Entry(dimProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DimProducts
        [HttpPost]
        public async Task<ActionResult<DimProduct>> PostDimProduct(DimProduct dimProduct)
        {
            _context.DimProducts.Add(dimProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDimProduct", new { id = dimProduct.ProductKey }, dimProduct);
        }

        // DELETE: api/DimProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDimProduct(int id)
        {
            var dimProduct = await _context.DimProducts.FindAsync(id);
            if (dimProduct == null)
            {
                return NotFound();
            }

            _context.DimProducts.Remove(dimProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DimProductExists(int id)
        {
            return _context.DimProducts.Any(e => e.ProductKey == id);
        }
    }
}
