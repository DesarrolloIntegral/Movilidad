using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/empresas")]
    public class EmpresasController : ControllerBase
    {
        private readonly DataContext _context;

        public EmpresasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Empresa.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var empresa = await _context.Empresa
                .FirstOrDefaultAsync(x => x.Id == id);
            if (empresa is null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Empresa empresa)
        {
            try
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return Ok(empresa);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una emppresa con este nombre");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe una emppresa con este nombre");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Empresa empresa)
        {
            try
            {
                _context.Update(empresa);
                await _context.SaveChangesAsync();
                return Ok(empresa);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una emppresa con este nombre");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe una emppresa con este nombre");
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
