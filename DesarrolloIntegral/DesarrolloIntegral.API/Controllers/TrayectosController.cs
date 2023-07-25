﻿using DesarrolloIntegral.API.Data;
using DesarrolloIntegral.API.Helpers;
using DesarrolloIntegral.Shared.DTOs;
using DesarrolloIntegral.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Controllers
{
    [ApiController]
    [Route("/api/trayectos")]

    public class TrayectosController : ControllerBase
    {
        private readonly DataContext _context;

        public TrayectosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Trayectos
                .Include(p => p.Punto)
                .Include(r => r.Ruta)
                .Where(x => x.Ruta!.Id == pagination.Id)
                .AsQueryable();

            return Ok(await queryable
                        .Paginate(pagination)
                        .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Trayectos
                .Where(x => x.Ruta!.Id == pagination.Id)
                .AsQueryable();

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var trayecto = await _context.Trayectos
                .Include(p => p.Punto)
                .Include(r => r.Ruta)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (trayecto is null)
            {
                return NotFound();
            }

            return Ok(trayecto);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Trayecto trayecto)
        {
            try
            {
                trayecto.Estado = 1;
                _context.Add(trayecto);
                await _context.SaveChangesAsync();
                return Ok(trayecto);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe trayecto con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe trayecto con esos datos");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Trayecto trayecto)
        {
            try
            {
                trayecto.Ruta = null;
                trayecto.Punto = null;
                _context.Update(trayecto);
                await _context.SaveChangesAsync();
                return Ok(trayecto);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe trayecto con esos datos");
                }
                if (dbUpdateException.InnerException!.Message.Contains("duplicada"))
                {
                    return BadRequest("Ya existe trayecto con esos datos");
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
