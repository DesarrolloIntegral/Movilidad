using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/origendestino")]
    public class DescuentosOrigenDestinoController : ControllerBase
    {
        private readonly DataContext _context;

        public DescuentosOrigenDestinoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.DescuentosOrigenDestino
                .Include(n => n.PuntoOrigen)
                .Include(n => n.PuntoDestino)
                .Include(d => d.DescuentoDetalle)
                .Where(x => x.DescuentoDetalle!.Id == pagination.Id)
                .AsQueryable();

            return Ok(await queryable
                        .Paginate(pagination)
                        .ToListAsync());

        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.DescuentosOrigenDestino
                .Where(x => x.DescuentoDetalle!.Id == pagination.Id)
                .AsQueryable();

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var origendestino = await _context.DescuentosOrigenDestino
                .FirstOrDefaultAsync(x => x.Id == id);

            if (origendestino is null)
            {
                return NotFound();
            }

            return Ok(origendestino);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(DescuentoOrigenDestino origendestino)
        {
            try
            {
                origendestino.Estado = 1;
                _context.Add(origendestino);
                await _context.SaveChangesAsync();
                return Ok(origendestino);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe descuento con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe descuento con esos datos");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(DescuentoOrigenDestino origendestino)
        {
            try
            {
                origendestino.DescuentoDetalle = null;
                origendestino.PuntoOrigen = null;
                origendestino.PuntoDestino = null;
                _context.Update(origendestino);
                await _context.SaveChangesAsync();
                return Ok(origendestino);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe descuento con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe descuento con esos datos");
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
