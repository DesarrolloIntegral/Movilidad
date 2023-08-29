using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/itinerarios")]
    public class ItinerariosController : ControllerBase
    {
        private readonly DataContext _context;

        public ItinerariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Itinerarios
                .Include(r => r.Ruta)
                .ThenInclude(l => l.Linea)
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
            var itinerarios = await _context.Itinerarios
                .Include(r => r.Ruta)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itinerarios is null)
            {
                return NotFound();
            }

            return Ok(itinerarios);
        }

        //para generar los tiempos de recorrido
        [HttpGet("{Id:int}/{prueba1:int}")]
        public async Task<IActionResult> GetAsync(int Id, int prueba1)
        {
            return Ok(await _context.Itinerarios
                .Include(r => r.Ruta)
                .ThenInclude(t => t!.Trayectos)
                .Where(p => p.Id == Id)
                .ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync(Itinerario itinerario)
        {
            try
            {
                itinerario.Estado = 1;
                _context.Add(itinerario);
                await _context.SaveChangesAsync();
                return Ok(itinerario);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un itinerario con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un itinerario con esos datos");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Itinerario itinerario)
        {
            try
            {
                itinerario.Ruta = null;
                _context.Update(itinerario);
                await _context.SaveChangesAsync();
                return Ok(itinerario);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un itinerario con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un itinerario con esos datos");
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
