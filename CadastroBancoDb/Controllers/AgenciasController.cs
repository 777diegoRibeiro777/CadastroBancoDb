using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroBancoDb.Models;
using CadastroBancoDb.Context;

namespace CadastroBancoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        private readonly Db_CadastroDeBancoContext _context;

        public AgenciasController(Db_CadastroDeBancoContext context)
        {
            _context = context;
        }

        // GET: api/Agencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agencium>>> GetAgencia()
        {
          if (_context.Agencia == null)
          {
              return NotFound();
          }
            return await _context.Agencia.ToListAsync();
        }

        // GET: api/Agencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agencium>> GetAgencium(int id)
        {
          if (_context.Agencia == null)
          {
              return NotFound();
          }
            var agencium = await _context.Agencia.FindAsync(id);

            if (agencium == null)
            {
                return NotFound();
            }

            return agencium;
        }

        // PUT: api/Agencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgencium(int id, Agencium agencium)
        {
            if (id != agencium.NumeroAgencia)
            {
                return BadRequest();
            }

            _context.Entry(agencium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenciumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Agencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agencium>> PostAgencium(Agencium agencium)
        {
          if (_context.Agencia == null)
          {
              return Problem("Entity set 'Db_CadastroDeBancoContext.Agencia'  is null.");
          }
            _context.Agencia.Add(agencium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AgenciumExists(agencium.NumeroAgencia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAgencium", new { id = agencium.NumeroAgencia }, agencium);
        }

        // DELETE: api/Agencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgencium(int id)
        {
            if (_context.Agencia == null)
            {
                return NotFound();
            }
            var agencium = await _context.Agencia.FindAsync(id);
            if (agencium == null)
            {
                return NotFound();
            }

            _context.Agencia.Remove(agencium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgenciumExists(int id)
        {
            return (_context.Agencia?.Any(e => e.NumeroAgencia == id)).GetValueOrDefault();
        }
    }
}
