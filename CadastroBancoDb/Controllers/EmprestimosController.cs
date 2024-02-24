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
    public class EmprestimosController : ControllerBase
    {
        private readonly CadastroBancoDbContext _context;

        public EmprestimosController(CadastroBancoDbContext context)
        {
            _context = context;
        }

        // GET: api/Emprestimos
        [HttpGet]
        [Authorize]

        public async Task<ActionResult<IEnumerable<Emprestimo>>> GetEmprestimos()
        {
          if (_context.Emprestimos == null)
          {
              return NotFound();
          }
            return await _context.Emprestimos.ToListAsync();
        }

        // GET: api/Emprestimos/5
        [HttpGet("{id}")]
        [Authorize]

        public async Task<ActionResult<Emprestimo>> GetEmprestimo(int id)
        {
          if (_context.Emprestimos == null)
          {
              return NotFound();
          }
            var emprestimo = await _context.Emprestimos.FindAsync(id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return emprestimo;
        }

        // PUT: api/Emprestimos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]

        public async Task<IActionResult> PutEmprestimo(int id, Emprestimo emprestimo)
        {
            if (id != emprestimo.Idemprestimo)
            {
                return BadRequest();
            }

            _context.Entry(emprestimo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmprestimoExists(id))
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

        // POST: api/Emprestimos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Emprestimo>> PostEmprestimo(Emprestimo emprestimo)
        {
          if (_context.Emprestimos == null)
          {
              return Problem("Entity set 'CadastroBancoDbContext.Emprestimos'  is null.");
          }
            _context.Emprestimos.Add(emprestimo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmprestimoExists(emprestimo.Idemprestimo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmprestimo", new { id = emprestimo.Idemprestimo }, emprestimo);
        }

        // DELETE: api/Emprestimos/5
        [HttpDelete("{id}")]
        [Authorize]

        public async Task<IActionResult> DeleteEmprestimo(int id)
        {
            if (_context.Emprestimos == null)
            {
                return NotFound();
            }
            var emprestimo = await _context.Emprestimos.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            _context.Emprestimos.Remove(emprestimo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmprestimoExists(int id)
        {
            return (_context.Emprestimos?.Any(e => e.Idemprestimo == id)).GetValueOrDefault();
        }
    }
}
