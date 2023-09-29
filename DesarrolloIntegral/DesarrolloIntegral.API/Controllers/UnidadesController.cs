using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/unidades")]

    public class UnidadesController : ControllerBase
    {
        private readonly DataContext _context;

        public UnidadesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("sinfiltro")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Unidades
                .Where(u => u.Estado == 1)
                .OrderBy(p => p.NumeroEconomico).ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Unidades
                .AsQueryable();

            return Ok(await queryable
                        .Paginate(pagination)
                        .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Unidades.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
                var unidad = await _context.Unidades.FirstOrDefaultAsync(x => x.Id == id);

                if (unidad is null)
                {
                    return NotFound();
                }

                return Ok(unidad);
        }


        [HttpGet("{IdUnidad:int}/{idCero:int}")]
        public async Task<IActionResult> GetFullAsync(int IdUnidad, int idCero)
        {
            var res = await _context.Unidades
                .Where(x => x.IdUnidad == IdUnidad)
                .OrderByDescending(o => o.IdHistorial)
                .FirstOrDefaultAsync();

            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Unidad unidad)
        {
            try
            {
                unidad.Estado = 1;
                unidad.IdHistorial= 1;
                _context.Add(unidad);
                await _context.SaveChangesAsync();
                return Ok(unidad);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una unidad con estos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe una unidad con estos datos");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Unidad unidad)
        {
            try
            {
                _context.Update(unidad);
                await _context.SaveChangesAsync();
                return Ok(unidad);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una unidad con estos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe una unidad con estos datos");
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
