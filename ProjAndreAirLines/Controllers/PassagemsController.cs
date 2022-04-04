using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjAndreAirLines.Data;
using ProjAndreAirLines.Model;

namespace ProjAndreAirLines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagemsController : ControllerBase
    {
        private readonly ProjAndreAirLinesContext _context;

        public PassagemsController(ProjAndreAirLinesContext context)
        {
            _context = context;
        }

        // GET: api/Passagems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passagem>>> GetPassagem()
        {
            return await _context.Passagem.Include(v => v.Voo)
                                          .Include(p => p.Passageiro)
                                          .Include(c => c.Classe)
                                          .ToListAsync();
        }

        // GET: api/Passagems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passagem>> GetPassagem(int id)
        {
            var passagem = await _context.Passagem.Include(v => v.Voo)
                                                  .Include(p => p.Passageiro)
                                                  .Include(c => c.Classe)
                                                  .Where(i => i.Id == id)
                                                  .FirstOrDefaultAsync();

            if (passagem == null)
            {
                return NotFound();
            }

            return passagem;
        }

        // PUT: api/Passagems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassagem(int id, Passagem passagem)
        {
            if (id != passagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(passagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassagemExists(id))
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

        // POST: api/Passagems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passagem>> PostPassagem(Passagem passagem)
        {
            var voo = await _context.Voo
                        .Where(v => v.Id == passagem.Voo.Id)
                        .FirstOrDefaultAsync();

            var passageiro = await _context.Passageiro
                        .Where(p => p.CPF == passagem.Passageiro.CPF)
                        .FirstOrDefaultAsync();

            var classe = await _context.Classe
                           .Where(c => c.Id == passagem.Classe.Id)
                           .FirstOrDefaultAsync();

            var precoBase = await _context.PrecoBase
                           .Where(b => b.Classe.Id == passagem.Classe.Id)
                           .FirstOrDefaultAsync();

           
            passagem.Voo = voo;
            passagem.Passageiro = passageiro;
            passagem.Classe = classe;
            passagem.Valor = precoBase.Valor;

            _context.Passagem.Add(passagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassagem", new { id = passagem.Id }, passagem);
        }

        // DELETE: api/Passagems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassagem(int id)
        {
            var passagem = await _context.Passagem.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }

            _context.Passagem.Remove(passagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassagemExists(int id)
        {
            return _context.Passagem.Any(e => e.Id == id);
        }
    }
}
