using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/unidadOperadores")]

    public class UnidadOperadoresController : ControllerBase
    {
        private readonly DataContext _context;

        public UnidadOperadoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.UnidadOperadores
                .Include(n => n.Unidad)
                .Include(n => n.Linea)
                .Include(d => d.Personal)
                .AsQueryable();

            return Ok(await queryable
                        .Paginate(pagination)
                        .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.UnidadOperadores.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var asigna = await _context.UnidadOperadores
                .Include(n => n.Unidad)
                .Include(n => n.Linea)
                .Include(d => d.Personal)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (asigna is null)
            {
                return NotFound();
            }

            return Ok(asigna);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(UnidadOperador unidadOperador)
        {
            try
            {
                unidadOperador.Estado = 1;
                _context.Add(unidadOperador);
                await _context.SaveChangesAsync();
                return Ok(unidadOperador);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una asignacion con estos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe una asignacion con estos datos");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(UnidadOperador unidadOperador)
        {
            try
            {
                unidadOperador.Linea = null;
                unidadOperador.Unidad = null;
                unidadOperador.Personal= null;
                _context.Update(unidadOperador);
                await _context.SaveChangesAsync();
                return Ok(unidadOperador);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una asignacion con estos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe una asignacion con estos datos");
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
