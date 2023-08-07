using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/tarifas")]
    public class TarifasController : ControllerBase
    {
        private readonly DataContext _context;

        public TarifasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Tarifas
                .Include(l => l.Linea)
                .AsQueryable();

            return Ok(await queryable
                .OrderBy(x => x.Nombre)
                .Paginate(pagination)
                .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Tarifas.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("full")]
        public async Task<IActionResult> GetFullAsync()
        {
            return Ok(await _context.Tarifas
                .ToListAsync());
        }

        [HttpGet("{id:int}/{idActual:int}")]
        public async Task<IActionResult> GetFullAsync(int id, int idActual)
        {
            return Ok(await _context.Tarifas
                .Where(t => t.Id != idActual)
                .OrderBy(x => x.Nombre)
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var tarifa = await _context.Tarifas
                .Include(l =>l.Linea)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (tarifa is null)
            {
                return NotFound();
            }

            return Ok(tarifa);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Tarifa tarifa)
        {
            try
            {
                tarifa.Estado = 1;
                _context.Add(tarifa);
                await _context.SaveChangesAsync();
                return Ok(tarifa);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una tarifa con este nombre");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe una tarifa con este nombre");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Tarifa tarifa)
        {
            try
            {
                tarifa.Linea = null;
                _context.Update(tarifa);
                await _context.SaveChangesAsync();
                return Ok(tarifa);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una tarifa con este nombre");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe una tarifa con este nombre");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
