using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/viajes")]

    public class ViajesController : ControllerBase
    {
        private readonly DataContext _context;

        public ViajesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Viajes
                .Include(o1 => o1.Operador1)
                .Include(o2 => o2.Operador2)
                .Include(r => r.RolesDiarios)
                .Include(u => u.Unidad)
                .AsQueryable();

            return Ok(await queryable
                        .Paginate(pagination)
                        .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Viajes.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var viaje = await _context.Viajes
                .Include(o1 => o1.Operador1)
                .Include(o2 => o2.Operador2)
                .Include(r => r.RolesDiarios)
                .Include(u => u.Unidad)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (viaje is null)
            {
                return NotFound();
            }

            return Ok(viaje);
        }

        //para el consecutivo del idrecorrido
        [HttpGet("{IdCero1:int}/{IdCero2:int}")]
        public async Task<IActionResult> GetAsync(int IdCero1, int IdCero2)
        {
            var Ultimo = await _context.Viajes
                .OrderByDescending(r => r.IdRecorrido)
                .FirstOrDefaultAsync();

            if (Ultimo is null)
            {
                Viaje viaje = new Viaje();
                Ultimo = viaje;
            }

            return Ok(Ultimo);
        }

        //para el viajesindex.
        [HttpGet("{id:int}/{rol:int}/{iti:int}")]
        public async Task<ActionResult> GetAsync(int id, int rol, int iti)
        {
            var viajes = await _context.Viajes
                .Include(r => r.RolesDiarios)
                .ThenInclude(i => i!.Itinerario)
                .ThenInclude(r => r!.Ruta)
                .ToListAsync();

            if (viajes is null)
            {
                return NotFound();
            }

            return Ok(viajes);
        }



        [HttpPost]
        public async Task<ActionResult> PostAsync(Viaje viaje)
        {
            try
            {
                viaje.Estado = 1;
                _context.Add(viaje);
                await _context.SaveChangesAsync();
                return Ok(viaje);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con estos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un registro con estos datos");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Viaje viaje)
        {
            try
            {
                viaje.Operador1 = null;
                viaje.Operador2 = null;
                viaje.RolesDiarios = null;
                viaje.Unidad = null;
                _context.Update(viaje);
                await _context.SaveChangesAsync();
                return Ok(viaje);

            } 
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con estos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un registro con estos datos");
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
