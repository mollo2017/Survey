using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapaDatos.Seguridad;
using SuerveyAPI.Data;

namespace SuerveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccionesController : ControllerBase
    {
        private readonly SuerveyAPIContext _context;

        public AccionesController(SuerveyAPIContext context)
        {
            _context = context;
        }

        // GET: api/Acciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acciones>>> GetAcciones()
        {
          if (_context.Acciones == null)
          {
              return NotFound();
          }
            return await _context.Acciones.ToListAsync();
        }

        // GET: api/Acciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acciones>> GetAcciones(int id)
        {
          if (_context.Acciones == null)
          {
              return NotFound();
          }
            var acciones = await _context.Acciones.FindAsync(id);

            if (acciones == null)
            {
                return NotFound();
            }

            return acciones;
        }

        // PUT: api/Acciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcciones(int id, Acciones acciones)
        {
            if (id != acciones.IdAccion)
            {
                return BadRequest();
            }

            _context.Entry(acciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccionesExists(id))
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

        // POST: api/Acciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acciones>> PostAcciones(Acciones acciones)
        {
          if (_context.Acciones == null)
          {
              return Problem("Entity set 'SuerveyAPIContext.Acciones'  is null.");
          }
            _context.Acciones.Add(acciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcciones", new { id = acciones.IdAccion }, acciones);
        }

        // DELETE: api/Acciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcciones(int id)
        {
            if (_context.Acciones == null)
            {
                return NotFound();
            }
            var acciones = await _context.Acciones.FindAsync(id);
            if (acciones == null)
            {
                return NotFound();
            }

            _context.Acciones.Remove(acciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccionesExists(int id)
        {
            return (_context.Acciones?.Any(e => e.IdAccion == id)).GetValueOrDefault();
        }
    }
}
