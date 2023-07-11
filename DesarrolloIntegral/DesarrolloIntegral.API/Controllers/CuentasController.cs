using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared;
using DesarrolloIntegral.Shared.DTOs;
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
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Cuentas
                .Where(x => x.Banco!.Id == pagination.Id)
                .AsQueryable();

            return Ok(await queryable
                        .OrderBy(x => x.NumeroCuenta)
                        .Paginate(pagination)
                        .ToListAsync());

        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Cuentas
                .Where(x => x.Banco!.Id == pagination.Id)
                .AsQueryable();

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var perfil = await _context.Cuentas
                .FirstOrDefaultAsync(x => x.Id == id);
            if (perfil is null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(CuentaBancaria cuenta)
        {
            try
            {
                cuenta.EstadoCuenta = 1;
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

        [HttpPut]
        public async Task<ActionResult> PutAsync(CuentaBancaria cuenta)
        {
            try
            {
                _context.Update(cuenta);
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
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
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
