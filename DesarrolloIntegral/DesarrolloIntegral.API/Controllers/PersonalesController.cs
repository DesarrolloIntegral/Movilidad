using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/personales")]
    public class PersonalesController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonalesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Personal
                .AsQueryable();

            return Ok(await queryable
                .Include(p => p.Puesto)
                .OrderBy(x => x.Nombre)
                .Paginate(pagination)
                .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Personal.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var personal = await _context.Personal
                .Include(p => p.Puesto)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (personal is null)
            {
                return NotFound();
            }

            return Ok(personal);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Personal personal)
        {
            try
            {
                personal.Estado = 1;
                _context.Add(personal);
                await _context.SaveChangesAsync();
                return Ok(personal);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un empleado con este nombre");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un empleado con este nombre");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Personal personal)
        {
            try
            {
                personal.Puesto = null;
                _context.Update(personal);
                await _context.SaveChangesAsync();
                return Ok(personal);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un puesto con este nombre");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe un puesto con este nombre");
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
            var personal = await _context.Personal.FirstOrDefaultAsync(x => x.Id == id);

            if (personal == null)
            {
                return NotFound();
            }

            _context.Remove(personal);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
