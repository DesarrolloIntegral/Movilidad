using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/horariosServicio")]
    public class HorariosServicioController : ControllerBase
    {
        private readonly DataContext _context;

        public HorariosServicioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.HorarioServicios
                .Include(r => r.Itinerario)
                .Include(t => t.Trayecto)
                .ThenInclude(n => n!.Punto)
                .AsQueryable();

            return Ok(await queryable
                        .Paginate(pagination)
                        .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Itinerarios.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var horarios = await _context.HorarioServicios.FirstOrDefaultAsync(x => x.Id == id);

            if (horarios is null)
            {
                return NotFound();
            }

            return Ok(horarios);
        }

        //para mostrarlo cuando se generen los horarios
        [HttpGet("{Id:int}/{prueba1:int}")]
        public async Task<IActionResult> GetAsync(int Id, int prueba1)
        {
            return Ok(await _context.HorarioServicios
                .Include(t => t.Trayecto)
                .ThenInclude(p => p!.Punto)
                .Where(p => p.ItinerarioId == Id)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(HorarioServicio horarioServicio)
        {
            try
            {
                horarioServicio.Estado = 1;
                _context.Add(horarioServicio);
                await _context.SaveChangesAsync();
                return Ok(horarioServicio);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un horario con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un horario con esos datos");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(HorarioServicio horarioServicio)
        {
            try
            {
                horarioServicio.Itinerario = null;
                horarioServicio.Trayecto = null;
                _context.Update(horarioServicio);
                await _context.SaveChangesAsync();
                return Ok(horarioServicio);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un horario con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un horario con esos datos");
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
