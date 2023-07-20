using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/descuentosdetalles")]
    public class DescuentosDetallesController : ControllerBase
    {
        private readonly DataContext _context;

        public DescuentosDetallesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.DescuentosDetalles
                .Include(od => od.OrigenDestinos)
                .Include(l => l.Linea)
                .Where(x => x.Descuento!.Id == pagination.Id)
                .AsQueryable();

            return Ok(await queryable
                        .Paginate(pagination)
                        .ToListAsync());

        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.DescuentosDetalles
                .Where(x => x.Descuento!.Id == pagination.Id)
                .AsQueryable();

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var detalle = await _context.DescuentosDetalles
                .Include(l => l.Linea)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (detalle is null)
            {
                return NotFound();
            }

            return Ok(detalle);
        }

        [HttpGet("{id:int}/{cero:int}")]
        public async Task<ActionResult> GetAsync(int id, int cero)
        {
            var detalle = await _context.DescuentosDetalles
                .Include(d => d.Descuento)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (detalle is null)
            {
                return NotFound();
            }

            return Ok(detalle);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(DescuentoDetalle detalle)
        {
            try
            {
                detalle.Estado = 1;
                _context.Add(detalle);
                await _context.SaveChangesAsync();
                return Ok(detalle);
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
        public async Task<ActionResult> PutAsync(DescuentoDetalle detalle)
        {
            try
            {
                detalle.Linea = null;
                detalle.Descuento = null;
                _context.Update(detalle);
                await _context.SaveChangesAsync();
                return Ok(detalle);

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
