using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/tarifasDetalle")]

    public class TarifasDetalleController : ControllerBase
    {
        private readonly DataContext _context;

        public TarifasDetalleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.TarifasDetalle
                .Include(n => n.PuntoOrigen)
                .Include(n => n.PuntoDestino)
                .Include(d => d.Tarifa)
                .Where(x => x.Tarifa!.Id == pagination.Id)
                .AsQueryable();

            return Ok(await queryable
                        .Paginate(pagination)
                        .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.TarifasDetalle
                .Where(x => x.Tarifa!.Id == pagination.Id)
                .AsQueryable();

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var tarifaDetalle = await _context.TarifasDetalle
                .FirstOrDefaultAsync(x => x.Id == id);

            if (tarifaDetalle is null)
            {
                return NotFound();
            }

            return Ok(tarifaDetalle);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Shared.Models.TarifaDetalle tarifadetalle)
        {
            try
            {
                tarifadetalle.Estado = 1;
                _context.Add(tarifadetalle);
                await _context.SaveChangesAsync();
                return Ok(tarifadetalle);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe detalle con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe detalle con esos datos");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Shared.Models.TarifaDetalle tarifadetalle)
        {
            try
            {
                tarifadetalle.Tarifa = null;
                tarifadetalle.PuntoOrigen = null;
                tarifadetalle.PuntoDestino = null;
                _context.Update(tarifadetalle);
                await _context.SaveChangesAsync();
                return Ok(tarifadetalle);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe detalle con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe detalle con esos datos");
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
