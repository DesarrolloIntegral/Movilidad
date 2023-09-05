using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/intervalos")]
    public class IntervalosController : ControllerBase
    {
        private readonly DataContext _context;

        public IntervalosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Intervalos
                .Include(i => i.Itinerario)
                .Include(t => t.Trayecto)
                .ThenInclude(p => p!.Punto)
                .AsQueryable();

            return Ok(await queryable
                        .Paginate(pagination)
                        .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Intervalos.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var intervalos = await _context.Intervalos
                .Include(i => i.Itinerario)
                .Include(t => t.Trayecto)
                .ThenInclude(p => p!.Punto)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (intervalos is null)
            {
                return NotFound();
            }

            return Ok(intervalos);
        }

        //Id/0
        [HttpGet("{Id:int}/{itinerario:int}")]
        public async Task<IActionResult> GetAsync(int Id, int itinerario)
        {
            return Ok(await _context.Intervalos
                .Include(i => i.Itinerario)
                .Include(t => t.Trayecto)
                .ThenInclude(p => p!.Punto)
                .Where(p => p.ItinerarioId == Id)
                .ToListAsync());
        }

        //Id/0/0  para sacar el consecutivo del recorrido
        [HttpGet("{IdItinerario:int}/{IdIntervalo:int}/{IdRecorrido:int}")]
        public async Task<IActionResult> GetAsync(int IdItinerario, int IdIntervalo, int IdRecorrido)
        {
            var Ultimo = await _context.Intervalos
                .OrderByDescending(r => r.IdRecorrido)
                .FirstOrDefaultAsync();

            if (Ultimo is null)
            {
                Intervalo intervalo = new Intervalo();
                Ultimo = intervalo;
            }

            return Ok(Ultimo);
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync(Intervalo intervalo)
        {
            try
            {
                intervalo.Estado = 1;
                _context.Add(intervalo);
                await _context.SaveChangesAsync();
                return Ok(intervalo);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un intervalo con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un intervalo con esos datos");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Intervalo intervalo)
        {
            try
            {
                intervalo.Trayecto = null;
                intervalo.Itinerario = null;
                _context.Update(intervalo);
                await _context.SaveChangesAsync();
                return Ok(intervalo);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un intervalo con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un intervalo con esos datos");
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
