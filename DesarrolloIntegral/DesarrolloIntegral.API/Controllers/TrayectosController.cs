using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/trayectos")]

    public class TrayectosController : ControllerBase
    {
        private readonly DataContext _context;

        public TrayectosController(DataContext context)
        {
            _context = context;
        }

        //para sacar la ultima posicion en la ruta
        [HttpGet("{Id:int}/{prueba:int}")]
        public async Task<IActionResult> GetAsync(int Id, int prueba)
        {
            var Res = await _context.Trayectos
                .Where(p => p.RutaId == Id)
                .OrderByDescending(o => o.Posicion).FirstOrDefaultAsync();

            if (Res== null)
            {
                return Ok(new Trayecto());
            }
            else
            {
                return Ok(Res);
            }
        }

        //para cargar los datos completos de la ruta para subir-bajar
        [HttpGet("{Id:int}/{prueba1:int}/{prueba2:int}")]
        public async Task<IActionResult> GetAsync(int Id, int prueba1, int prueba2)
        {
                return Ok(await _context.Trayectos
                .Where(p => p.RutaId == Id)
                .ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Trayectos
                .Include(p => p.Punto)
                .Include(r => r.Ruta)
                .Where(x => x.Ruta!.Id == pagination.Id)
                .OrderBy(x => x.Posicion)
                .AsQueryable();

            return Ok(await queryable
                        .Paginate(pagination)
                        .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Trayectos
                .Where(x => x.Ruta!.Id == pagination.Id)
                .AsQueryable();

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var trayecto = await _context.Trayectos
                .Include(p => p.Punto)
                .Include(r => r.Ruta)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (trayecto is null)
            {
                return NotFound();
            }

            return Ok(trayecto);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Trayecto trayecto)
        {
            try
            {
                trayecto.Estado = 1;
                _context.Add(trayecto);
                await _context.SaveChangesAsync();
                return Ok(trayecto);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe trayecto con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe trayecto con esos datos");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Trayecto trayecto)
        {
            try
            {
                trayecto.Ruta = null;
                trayecto.Punto = null;
                _context.Update(trayecto);
                await _context.SaveChangesAsync();
                return Ok(trayecto);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe trayecto con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe trayecto con esos datos");
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
