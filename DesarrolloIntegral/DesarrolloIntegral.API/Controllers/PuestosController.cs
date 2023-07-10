using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/puestos")]
    public class PuestosController : ControllerBase
    {
        private readonly DataContext _context;

        public PuestosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("sinfiltro")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Puestos
                .Include(s => s.Personals)
                .OrderBy(p => p.Nombre).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Puestos
                .Include(p => p.Personals)
                .AsQueryable();

            return Ok(await queryable
                .OrderBy(x => x.Nombre)
                .Paginate(pagination)
                .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Puestos.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var puesto = await _context.Puestos
                .Include(p => p.Personals)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (puesto is null)
            {
                return NotFound();
            }

            return Ok(puesto);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Puesto puesto)
        {
            try
            {
                _context.Add(puesto);
                await _context.SaveChangesAsync();
                return Ok(puesto);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un puesto con este nombre");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un puesto con este nombre");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Puesto puesto)
        {
            try
            {
                _context.Update(puesto);
                await _context.SaveChangesAsync();
                return Ok(puesto);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un puesto con este nombre");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un puesto con este nombre");
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
            var puesto = await _context.Puestos.FirstOrDefaultAsync(x => x.Id == id);

            if (puesto == null)
            {
                return NotFound();
            }

            _context.Remove(puesto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
