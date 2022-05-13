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
    public class RegistroUsuarioEncuestasController : ControllerBase
    {
        private readonly SuerveyAPIContext _context;

        public RegistroUsuarioEncuestasController(SuerveyAPIContext context)
        {
            _context = context;
        }

        // GET: api/RegistroUsuarioEncuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroUsuarioEncuesta>>> GetRegistroUsuarioEncuesta()
        {
          if (_context.RegistroUsuarioEncuesta == null)
          {
              return NotFound();
          }
            return await _context.RegistroUsuarioEncuesta.ToListAsync();
        }

        // GET: api/RegistroUsuarioEncuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroUsuarioEncuesta>> GetRegistroUsuarioEncuesta(int id)
        {
          if (_context.RegistroUsuarioEncuesta == null)
          {
              return NotFound();
          }
            var registroUsuarioEncuesta = await _context.RegistroUsuarioEncuesta.FindAsync(id);

            if (registroUsuarioEncuesta == null)
            {
                return NotFound();
            }

            return registroUsuarioEncuesta;
        }

        // PUT: api/RegistroUsuarioEncuestas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroUsuarioEncuesta(int id, RegistroUsuarioEncuesta registroUsuarioEncuesta)
        {
            if (id != registroUsuarioEncuesta.IdRegistroUsuarioEncuesta)
            {
                return BadRequest();
            }

            _context.Entry(registroUsuarioEncuesta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroUsuarioEncuestaExists(id))
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

        // POST: api/RegistroUsuarioEncuestas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistroUsuarioEncuesta>> PostRegistroUsuarioEncuesta(RegistroUsuarioEncuesta registroUsuarioEncuesta)
        {
          if (_context.RegistroUsuarioEncuesta == null)
          {
              return Problem("Entity set 'SuerveyAPIContext.RegistroUsuarioEncuesta'  is null.");
          }
            _context.RegistroUsuarioEncuesta.Add(registroUsuarioEncuesta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroUsuarioEncuesta", new { id = registroUsuarioEncuesta.IdRegistroUsuarioEncuesta }, registroUsuarioEncuesta);
        }

        // DELETE: api/RegistroUsuarioEncuestas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroUsuarioEncuesta(int id)
        {
            if (_context.RegistroUsuarioEncuesta == null)
            {
                return NotFound();
            }
            var registroUsuarioEncuesta = await _context.RegistroUsuarioEncuesta.FindAsync(id);
            if (registroUsuarioEncuesta == null)
            {
                return NotFound();
            }

            _context.RegistroUsuarioEncuesta.Remove(registroUsuarioEncuesta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistroUsuarioEncuestaExists(int id)
        {
            return (_context.RegistroUsuarioEncuesta?.Any(e => e.IdRegistroUsuarioEncuesta == id)).GetValueOrDefault();
        }
    }
}
