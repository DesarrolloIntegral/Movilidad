using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/lineas")]
    public class LineasController : ControllerBase
    {
        private readonly DataContext _context;

        public LineasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("sinfiltro")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Lineas
                .OrderBy(p => p.Nombre).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Lineas
                .AsQueryable();

            return Ok(await queryable
                .OrderBy(x => x.Nombre)
                .Paginate(pagination)
                .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Lineas.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var linea = await _context.Lineas
                .FirstOrDefaultAsync(x => x.Id == id);
            if (linea is null)
            {
                return NotFound();
            }

            return Ok(linea);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Linea linea)
        {
            try
            {
                linea.Estado = 1;
                _context.Add(linea);
                await _context.SaveChangesAsync();
                return Ok(linea);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un banco con este nombre");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un banco con este nombre");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Linea linea)
        {
            try
            {
                _context.Update(linea);
                await _context.SaveChangesAsync();
                return Ok(linea);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un banco con este nombre");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un banco con este nombre");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var linea = await _context.Lineas.FirstOrDefaultAsync(x => x.Id == id);

            if (linea == null)
            {
                return NotFound();
            }

            _context.Remove(linea);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
