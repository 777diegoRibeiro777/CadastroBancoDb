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
    public class TransacoesController : ControllerBase
    {
        private readonly CadastroBancoDbContext _context;

        public TransacoesController(CadastroBancoDbContext context)
        {
            _context = context;
        }

        // GET: api/Transacoes
        [HttpGet]
        [Authorize]

        public async Task<ActionResult<IEnumerable<Transacao>>> GetTransacaos()
        {
          if (_context.Transacaos == null)
          {
              return NotFound();
          }
            return await _context.Transacaos.ToListAsync();
        }

        // GET: api/Transacoes/5
        [HttpGet("{id}")]
        [Authorize]

        public async Task<ActionResult<Transacao>> GetTransacao(int id)
        {
          if (_context.Transacaos == null)
          {
              return NotFound();
          }
            var transacao = await _context.Transacaos.FindAsync(id);

            if (transacao == null)
            {
                return NotFound();
            }

            return transacao;
        }

        // PUT: api/Transacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]

        public async Task<IActionResult> PutTransacao(int id, Transacao transacao)
        {
            if (id != transacao.Idtransacao)
            {
                return BadRequest();
            }

            _context.Entry(transacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransacaoExists(id))
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

        // POST: api/Transacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Transacao>> PostTransacao(Transacao transacao)
        {
          if (_context.Transacaos == null)
          {
              return Problem("Entity set 'CadastroBancoDbContext.Transacaos'  is null.");
          }
            _context.Transacaos.Add(transacao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TransacaoExists(transacao.Idtransacao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTransacao", new { id = transacao.Idtransacao }, transacao);
        }

        // DELETE: api/Transacoes/5
        [HttpDelete("{id}")]
        [Authorize]

        public async Task<IActionResult> DeleteTransacao(int id)
        {
            if (_context.Transacaos == null)
            {
                return NotFound();
            }
            var transacao = await _context.Transacaos.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }

            _context.Transacaos.Remove(transacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransacaoExists(int id)
        {
            return (_context.Transacaos?.Any(e => e.Idtransacao == id)).GetValueOrDefault();
        }
    }
}
