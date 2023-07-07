using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/bancos")]
    public class BancosController : ControllerBase
    {
        private readonly DataContext _context;

        public BancosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Bancos
                .Include(x => x.Cuentas)
                .AsQueryable();

            return Ok(await queryable
                .OrderBy(x => x.NombreBanco)
                .Paginate(pagination)
                .ToListAsync());

        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Bancos.AsQueryable();
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }


        [HttpGet("full")]
        public async Task<IActionResult> GetFullAsync()
        {
            return Ok(await _context.Bancos
                .Include(x => x.Cuentas)
                .ToListAsync());
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var banco = await _context.Bancos
                .Include (x => x.Cuentas)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (banco is null)
            {
                return NotFound();
            }

            return Ok(banco);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Banco banco)
        {
            try
            {
                _context.Add(banco);
                await _context.SaveChangesAsync();
                return Ok(banco);

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
            catch(Exception exception)
            { 
                return BadRequest(exception.Message); 
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Banco banco)
        {
            try
            {
                _context.Update(banco);
                await _context.SaveChangesAsync();
                return Ok(banco);

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
            var banco = await _context.Bancos.FirstOrDefaultAsync(x => x.Id == id);

            if (banco == null)
            {
                return NotFound();
            }

            _context.Remove(banco);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
