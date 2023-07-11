using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/perfiles")]

    public class PerfilesController : ControllerBase
    {
        private readonly DataContext _context;

        public PerfilesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.PerfilesUsuario
                .AsQueryable();

            return Ok(await queryable
                .OrderBy(x => x.Nombre)
                .Paginate(pagination)
                .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.PerfilesUsuario.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var perfil = await _context.PerfilesUsuario
                .FirstOrDefaultAsync(x => x.Id == id);
            if (perfil is null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(PerfilUsuario perfil)
        {
            try
            {
                perfil.Estado = 1;
                _context.Add(perfil);
                await _context.SaveChangesAsync();
                return Ok(perfil);
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
        public async Task<ActionResult> PutAsync(PerfilUsuario perfil)
        {
            try
            {
                _context.Update(perfil);
                await _context.SaveChangesAsync();
                return Ok(perfil);
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
            var perfil = await _context.PerfilesUsuario.FirstOrDefaultAsync(x => x.Id == id);

            if (perfil == null)
            {
                return NotFound();
            }

            _context.Remove(perfil);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
