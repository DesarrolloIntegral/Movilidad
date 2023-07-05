using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/cuentas")]
    public class CuentasController : ControllerBase
    {
        private readonly DataContext _context;

        public CuentasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() 
        {
            return Ok(await _context.Cuentas.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var cuenta = await _context.Cuentas.FirstOrDefaultAsync(x => x.Id == id);
            if (cuenta is null)
            {
                return NotFound();
            }

            return Ok(cuenta);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(CuentaBancaria cuenta)
        {
            try
            {
                _context.Add(cuenta);
                await _context.SaveChangesAsync();
                return Ok(cuenta);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una cuenta con este número");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe una cuenta con este número");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var cuenta = await _context.Cuentas.FirstOrDefaultAsync(x => x.Id == id);

            if (cuenta == null)
            {
                return NotFound();
            }

            _context.Remove(cuenta);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
