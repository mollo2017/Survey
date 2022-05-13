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
    public class RegistroPreguntaRespuestasController : ControllerBase
    {
        private readonly SuerveyAPIContext _context;

        public RegistroPreguntaRespuestasController(SuerveyAPIContext context)
        {
            _context = context;
        }

        // GET: api/RegistroPreguntaRespuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroPreguntaRespuesta>>> GetRegistroPreguntaRespuesta()
        {
          if (_context.RegistroPreguntaRespuesta == null)
          {
              return NotFound();
          }
            return await _context.RegistroPreguntaRespuesta.ToListAsync();
        }

        // GET: api/RegistroPreguntaRespuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroPreguntaRespuesta>> GetRegistroPreguntaRespuesta(int id)
        {
          if (_context.RegistroPreguntaRespuesta == null)
          {
              return NotFound();
          }
            var registroPreguntaRespuesta = await _context.RegistroPreguntaRespuesta.FindAsync(id);

            if (registroPreguntaRespuesta == null)
            {
                return NotFound();
            }

            return registroPreguntaRespuesta;
        }

        // PUT: api/RegistroPreguntaRespuestas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroPreguntaRespuesta(int id, RegistroPreguntaRespuesta registroPreguntaRespuesta)
        {
            if (id != registroPreguntaRespuesta.IdRegistroPreguntaRespuesta)
            {
                return BadRequest();
            }

            _context.Entry(registroPreguntaRespuesta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroPreguntaRespuestaExists(id))
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

        // POST: api/RegistroPreguntaRespuestas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistroPreguntaRespuesta>> PostRegistroPreguntaRespuesta(RegistroPreguntaRespuesta registroPreguntaRespuesta)
        {
          if (_context.RegistroPreguntaRespuesta == null)
          {
              return Problem("Entity set 'SuerveyAPIContext.RegistroPreguntaRespuesta'  is null.");
          }
            _context.RegistroPreguntaRespuesta.Add(registroPreguntaRespuesta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroPreguntaRespuesta", new { id = registroPreguntaRespuesta.IdRegistroPreguntaRespuesta }, registroPreguntaRespuesta);
        }

        // DELETE: api/RegistroPreguntaRespuestas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroPreguntaRespuesta(int id)
        {
            if (_context.RegistroPreguntaRespuesta == null)
            {
                return NotFound();
            }
            var registroPreguntaRespuesta = await _context.RegistroPreguntaRespuesta.FindAsync(id);
            if (registroPreguntaRespuesta == null)
            {
                return NotFound();
            }

            _context.RegistroPreguntaRespuesta.Remove(registroPreguntaRespuesta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistroPreguntaRespuestaExists(int id)
        {
            return (_context.RegistroPreguntaRespuesta?.Any(e => e.IdRegistroPreguntaRespuesta == id)).GetValueOrDefault();
        }
    }
}
