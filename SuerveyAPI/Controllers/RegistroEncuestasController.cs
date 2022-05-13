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
    public class RegistroEncuestasController : ControllerBase
    {
        private readonly SuerveyAPIContext _context;

        public RegistroEncuestasController(SuerveyAPIContext context)
        {
            _context = context;
        }

        // GET: api/RegistroEncuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroEncuesta>>> GetRegistroEncuesta()
        {
          if (_context.RegistroEncuesta == null)
          {
              return NotFound();
          }
            return await _context.RegistroEncuesta.ToListAsync();
        }

        // GET: api/RegistroEncuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroEncuesta>> GetRegistroEncuesta(int id)
        {
          if (_context.RegistroEncuesta == null)
          {
              return NotFound();
          }
            var registroEncuesta = await _context.RegistroEncuesta.FindAsync(id);

            if (registroEncuesta == null)
            {
                return NotFound();
            }

            return registroEncuesta;
        }

        // PUT: api/RegistroEncuestas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroEncuesta(int id, RegistroEncuesta registroEncuesta)
        {
            if (id != registroEncuesta.IdRegistroEncuesta)
            {
                return BadRequest();
            }

            _context.Entry(registroEncuesta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroEncuestaExists(id))
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

        // POST: api/RegistroEncuestas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistroEncuesta>> PostRegistroEncuesta(RegistroEncuesta registroEncuesta)
        {
          if (_context.RegistroEncuesta == null)
          {
              return Problem("Entity set 'SuerveyAPIContext.RegistroEncuesta'  is null.");
          }
            _context.RegistroEncuesta.Add(registroEncuesta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroEncuesta", new { id = registroEncuesta.IdRegistroEncuesta }, registroEncuesta);
        }

        // DELETE: api/RegistroEncuestas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroEncuesta(int id)
        {
            if (_context.RegistroEncuesta == null)
            {
                return NotFound();
            }
            var registroEncuesta = await _context.RegistroEncuesta.FindAsync(id);
            if (registroEncuesta == null)
            {
                return NotFound();
            }

            _context.RegistroEncuesta.Remove(registroEncuesta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistroEncuestaExists(int id)
        {
            return (_context.RegistroEncuesta?.Any(e => e.IdRegistroEncuesta == id)).GetValueOrDefault();
        }
    }
}
