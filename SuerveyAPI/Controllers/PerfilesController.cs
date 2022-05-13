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
    public class PerfilesController : ControllerBase
    {
        private readonly SuerveyAPIContext _context;

        public PerfilesController(SuerveyAPIContext context)
        {
            _context = context;
        }

        // GET: api/Perfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfiles>>> GetPerfiles()
        {
          if (_context.Perfiles == null)
          {
              return NotFound();
          }
            return await _context.Perfiles.ToListAsync();
        }

        // GET: api/Perfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfiles>> GetPerfiles(int id)
        {
          if (_context.Perfiles == null)
          {
              return NotFound();
          }
            var perfiles = await _context.Perfiles.FindAsync(id);

            if (perfiles == null)
            {
                return NotFound();
            }

            return perfiles;
        }

        // PUT: api/Perfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfiles(int id, Perfiles perfiles)
        {
            if (id != perfiles.IdPerfil)
            {
                return BadRequest();
            }

            _context.Entry(perfiles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilesExists(id))
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

        // POST: api/Perfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Perfiles>> PostPerfiles(Perfiles perfiles)
        {
          if (_context.Perfiles == null)
          {
              return Problem("Entity set 'SuerveyAPIContext.Perfiles'  is null.");
          }
            _context.Perfiles.Add(perfiles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfiles", new { id = perfiles.IdPerfil }, perfiles);
        }

        // DELETE: api/Perfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfiles(int id)
        {
            if (_context.Perfiles == null)
            {
                return NotFound();
            }
            var perfiles = await _context.Perfiles.FindAsync(id);
            if (perfiles == null)
            {
                return NotFound();
            }

            _context.Perfiles.Remove(perfiles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerfilesExists(int id)
        {
            return (_context.Perfiles?.Any(e => e.IdPerfil == id)).GetValueOrDefault();
        }
    }
}
