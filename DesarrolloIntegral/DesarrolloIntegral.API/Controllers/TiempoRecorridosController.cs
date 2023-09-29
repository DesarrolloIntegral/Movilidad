using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/tiemposRecorrido")]

    public class TiempoRecorridosController : ControllerBase
    {
        private readonly DataContext _context;

        public TiempoRecorridosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.TiempoRecorridos
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
            var queryable = _context.TiempoRecorridos.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var tiempos = await _context.TiempoRecorridos
                .Include(t => t.Trayecto)
                .ThenInclude(p => p!.Punto)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (tiempos is null)
            {
                return NotFound();
            }

            return Ok(tiempos);
        }

        //para generar los tiempos de recorrido y tambien para los eventos
        [HttpGet("{Id:int}/{prueba1:int}")]
        public async Task<IActionResult> GetAsync(int Id, int prueba1)
        {
            return Ok(await _context.TiempoRecorridos
                .Include(t => t.Trayecto)
                .ThenInclude(p => p!.Punto)
                .Where(i => i.ItinerarioId == Id)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(TiempoRecorrido tiempoRecorrido)
        {
            try
            {
                tiempoRecorrido.Estado = 1;
                _context.Add(tiempoRecorrido);
                await _context.SaveChangesAsync();
                return Ok(tiempoRecorrido);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un registro con esos datos");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(TiempoRecorrido tiempoRecorrido)
        {
            try
            {
                tiempoRecorrido.Trayecto = null;
                _context.Update(tiempoRecorrido);
                await _context.SaveChangesAsync();
                return Ok(tiempoRecorrido);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un registro con esos datos");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{itinerarioId:int}")]
        public async Task<ActionResult> DeleteAsync(int itinerarioId)
        {
            try
            {
                var tiempos = await _context.TiempoRecorridos.Where(h => h.ItinerarioId == itinerarioId).ToListAsync();

                if (tiempos == null)
                {
                    return NotFound();
                }

                _context.RemoveRange(tiempos);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un registro con esos datos");
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
