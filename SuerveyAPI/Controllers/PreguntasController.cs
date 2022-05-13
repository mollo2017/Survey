using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapaDatos.Data;
using SuerveyAPI.Data;

namespace SuerveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntasController : ControllerBase
    {
        private readonly SuerveyAPIContext _context;

        public PreguntasController(SuerveyAPIContext context)
        {
            _context = context;
        }

        // GET: api/Preguntas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Preguntas>>> GetPreguntas()
        {
          if (_context.Preguntas == null)
          {
              return NotFound();
          }
            return await _context.Preguntas.ToListAsync();
        }

        // GET: api/Preguntas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Preguntas>> GetPreguntas(int id)
        {
          if (_context.Preguntas == null)
          {
              return NotFound();
          }
            var preguntas = await _context.Preguntas.FindAsync(id);

            if (preguntas == null)
            {
                return NotFound();
            }

            return preguntas;
        }

        // PUT: api/Preguntas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreguntas(int id, Preguntas preguntas)
        {
            if (id != preguntas.IdPregunta)
            {
                return BadRequest();
            }

            _context.Entry(preguntas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntasExists(id))
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

        // POST: api/Preguntas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Preguntas>> PostPreguntas(Preguntas preguntas)
        {
          if (_context.Preguntas == null)
          {
              return Problem("Entity set 'SuerveyAPIContext.Preguntas'  is null.");
          }
            _context.Preguntas.Add(preguntas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreguntas", new { id = preguntas.IdPregunta }, preguntas);
        }

        // DELETE: api/Preguntas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreguntas(int id)
        {
            if (_context.Preguntas == null)
            {
                return NotFound();
            }
            var preguntas = await _context.Preguntas.FindAsync(id);
            if (preguntas == null)
            {
                return NotFound();
            }

            _context.Preguntas.Remove(preguntas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreguntasExists(int id)
        {
            return (_context.Preguntas?.Any(e => e.IdPregunta == id)).GetValueOrDefault();
        }
    }
}
