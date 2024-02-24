using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroBancoDb.Models;
using Microsoft.AspNetCore.Authorization;

namespace CadastroBancoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly CadastroBancoDbContext _context;

        public ContasController(CadastroBancoDbContext context)
        {
            _context = context;
        }

        // GET: api/Contas
        [HttpGet]
        [Authorize]

        public async Task<ActionResult<IEnumerable<Contum>>> GetConta()
        {
          if (_context.Conta == null)
          {
              return NotFound();
          }
            return await _context.Conta.ToListAsync();
        }

        // GET: api/Contas/5
        [HttpGet("{id}")]
        [Authorize]

        public async Task<ActionResult<Contum>> GetContum(int id)
        {
          if (_context.Conta == null)
          {
              return NotFound();
          }
            var contum = await _context.Conta.FindAsync(id);

            if (contum == null)
            {
                return NotFound();
            }

            return contum;
        }

        // PUT: api/Contas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]

        public async Task<IActionResult> PutContum(int id, Contum contum)
        {
            if (id != contum.Idconta)
            {
                return BadRequest();
            }

            _context.Entry(contum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContumExists(id))
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

        // POST: api/Contas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Contum>> PostContum(Contum contum)
        {
          if (_context.Conta == null)
          {
              return Problem("Entity set 'CadastroBancoDbContext.Conta'  is null.");
          }
            _context.Conta.Add(contum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContumExists(contum.Idconta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContum", new { id = contum.Idconta }, contum);
        }

        // DELETE: api/Contas/5
        [HttpDelete("{id}")]
        [Authorize]

        public async Task<IActionResult> DeleteContum(int id)
        {
            if (_context.Conta == null)
            {
                return NotFound();
            }
            var contum = await _context.Conta.FindAsync(id);
            if (contum == null)
            {
                return NotFound();
            }

            _context.Conta.Remove(contum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContumExists(int id)
        {
            return (_context.Conta?.Any(e => e.Idconta == id)).GetValueOrDefault();
        }
    }
}
