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
    public class RegistroEncuestaPreguntasController : ControllerBase
    {
        private readonly SuerveyAPIContext _context;

        public RegistroEncuestaPreguntasController(SuerveyAPIContext context)
        {
            _context = context;
        }

        // GET: api/RegistroEncuestaPreguntas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroEncuestaPregunta>>> GetRegistroEncuestaPregunta()
        {
          if (_context.RegistroEncuestaPregunta == null)
          {
              return NotFound();
          }
            return await _context.RegistroEncuestaPregunta.ToListAsync();
        }

        // GET: api/RegistroEncuestaPreguntas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroEncuestaPregunta>> GetRegistroEncuestaPregunta(int id)
        {
          if (_context.RegistroEncuestaPregunta == null)
          {
              return NotFound();
          }
            var registroEncuestaPregunta = await _context.RegistroEncuestaPregunta.FindAsync(id);

            if (registroEncuestaPregunta == null)
            {
                return NotFound();
            }

            return registroEncuestaPregunta;
        }

        // PUT: api/RegistroEncuestaPreguntas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroEncuestaPregunta(int id, RegistroEncuestaPregunta registroEncuestaPregunta)
        {
            if (id != registroEncuestaPregunta.IdRegistroEncuestaPregunta)
            {
                return BadRequest();
            }

            _context.Entry(registroEncuestaPregunta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroEncuestaPreguntaExists(id))
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

        // POST: api/RegistroEncuestaPreguntas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistroEncuestaPregunta>> PostRegistroEncuestaPregunta(RegistroEncuestaPregunta registroEncuestaPregunta)
        {
          if (_context.RegistroEncuestaPregunta == null)
          {
              return Problem("Entity set 'SuerveyAPIContext.RegistroEncuestaPregunta'  is null.");
          }
            _context.RegistroEncuestaPregunta.Add(registroEncuestaPregunta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroEncuestaPregunta", new { id = registroEncuestaPregunta.IdRegistroEncuestaPregunta }, registroEncuestaPregunta);
        }

        // DELETE: api/RegistroEncuestaPreguntas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroEncuestaPregunta(int id)
        {
            if (_context.RegistroEncuestaPregunta == null)
            {
                return NotFound();
            }
            var registroEncuestaPregunta = await _context.RegistroEncuestaPregunta.FindAsync(id);
            if (registroEncuestaPregunta == null)
            {
                return NotFound();
            }

            _context.RegistroEncuestaPregunta.Remove(registroEncuestaPregunta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistroEncuestaPreguntaExists(int id)
        {
            return (_context.RegistroEncuestaPregunta?.Any(e => e.IdRegistroEncuestaPregunta == id)).GetValueOrDefault();
        }
    }
}
