﻿using DesarrolloIntegral.API.Data;
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
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Bancos.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var banco = await _context.Bancos.FirstOrDefaultAsync(x => x.IdBanco == id);
            if (banco is null)
            {
                return NotFound();
            }

            return Ok(banco);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Banco banco)
        {
            _context.Add(banco);
            await _context.SaveChangesAsync();
            return Ok(banco);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Banco banco)
        {
            _context.Update(banco);
            await _context.SaveChangesAsync();
            return Ok(banco);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var afectedRows = await _context.Bancos
                .Where(x => x.IdBanco == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}