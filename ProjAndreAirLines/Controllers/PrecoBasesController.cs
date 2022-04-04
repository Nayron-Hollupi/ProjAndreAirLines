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
    public class PrecoBasesController : ControllerBase
    {
        private readonly ProjAndreAirLinesContext _context;

        public PrecoBasesController(ProjAndreAirLinesContext context)
        {
            _context = context;
        }

        // GET: api/PrecoBases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrecoBase>>> GetPrecoBase()
        {
            return await _context.PrecoBase.Include(d => d.Destino)
                                           .Include(o => o.Origem)
                                           .Include(c => c.Classe)
                                            .ToListAsync();
        }

        // GET: api/PrecoBases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrecoBase>> GetPrecoBase(int id)
        {
            var precoBase = await _context.PrecoBase.Include(d => d.Destino)
                                                    .Include(o => o.Origem)
                                                    .Include(c => c.Classe)
                                                    .Where(i => i.Id == id)
                                                    .FirstOrDefaultAsync();

            if (precoBase == null)
            {
                return NotFound();
            }

            return precoBase;
        }

        // PUT: api/PrecoBases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrecoBase(int id, PrecoBase precoBase)
        {
            if (id != precoBase.Id)
            {
                return BadRequest();
            }

            _context.Entry(precoBase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrecoBaseExists(id))
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

        // POST: api/PrecoBases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrecoBase>> PostPrecoBase(PrecoBase precoBase)
        {

            var origem = await _context.Aeroporto
                           .Where(a => a.Sigla == precoBase.Origem.Sigla)
                           .FirstOrDefaultAsync();


            var destino = await _context.Aeroporto
                            .Where(a => a.Sigla == precoBase.Destino.Sigla)
                            .FirstOrDefaultAsync();


            var classe = await _context.Classe
                           .Where(c => c.Id == precoBase.Classe.Id)
                           .FirstOrDefaultAsync();

       
         

            precoBase.Origem = origem;
            precoBase.Destino = destino;
            precoBase.Classe = classe;
/*
            if(precoBase.Classe.Descricao == "Classe Economica")
            {
                precoBase.PromocaoPorcentagem = 0.2;
            }else if(precoBase.Classe.Descricao == "Classe Economica Premium")
            {
                precoBase.PromocaoPorcentagem = 0.15;
            }
            else if (precoBase.Classe.Descricao == "Classe Executiva ou Business")
            {
                precoBase.PromocaoPorcentagem = 0.1;
            }
            else if (precoBase.Classe.Descricao == "Primeira Classe")
            {
                precoBase.PromocaoPorcentagem = 0.07;
            }
            else
            {
                precoBase.PromocaoPorcentagem = 0;
            }*/
            double valor = (Convert.ToDouble(precoBase.Valor) + (precoBase.PromocaoPorcentagem * Convert.ToDouble(precoBase.Valor)));


            precoBase.Valor = Convert.ToDecimal(valor);



            _context.PrecoBase.Add(precoBase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrecoBase", new { id = precoBase.Id }, precoBase);
        }

        // DELETE: api/PrecoBases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrecoBase(int id)
        {



            var precoBase = await _context.PrecoBase.FindAsync(id);
            if (precoBase == null)
            {
                return NotFound();
            }

            _context.PrecoBase.Remove(precoBase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrecoBaseExists(int id)
        {
            return _context.PrecoBase.Any(e => e.Id == id);
        }
    }
}
