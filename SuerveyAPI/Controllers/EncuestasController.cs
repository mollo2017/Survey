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
    public class EncuestasController : ControllerBase
    {
        private readonly SuerveyAPIContext _context;

        public EncuestasController(SuerveyAPIContext context)
        {
            _context = context;
        }

        // GET: api/Encuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encuestas>>> GetEncuestas()
        {
          if (_context.Encuestas == null)
          {
              return NotFound();
          }
            return await _context.Encuestas.ToListAsync();
        }

        // GET: api/Encuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Encuestas>> GetEncuestas(int id)
        {
          if (_context.Encuestas == null)
          {
              return NotFound();
          }
            var encuestas = await _context.Encuestas.FindAsync(id);

            if (encuestas == null)
            {
                return NotFound();
            }

            return encuestas;
        }

        /// <summary>
        /// Obtener datos de encuestas filtrados, puede recuperar encuestas contestadas por usuario
        /// </summary>
        /// <param name="id"> Identificador de encuesta</param>
        /// <param name="nombre">Nombre de encuesta</param>
        /// <param name="estatus">estatus de la encuesta</param>
        /// <param name="idCategoria">Identificador de categoria</param>
        /// <param name="idUsuario">Identificador de usuario</param>
        /// <returns></returns>
        [HttpGet("GetEncuestasPorUsuario")]
        
        public async Task<IEnumerable<EncuestaSelect>> GetEncuestasPorUsuario([FromQuery]int id, [FromQuery] string nombre, [FromQuery] bool estatus, [FromQuery] int idCategoria, int? idUsuario = null)
        {
            
            return await _context.Set<EncuestaSelect>().FromSqlInterpolated($@"EXEC SPR_EncuestasSeleccionar
                                                                            @Nombre={nombre},
                                                                            @IdEncuesta={id},
                                                                            @Estatus={estatus},
                                                                            @IdCategoria={idCategoria},
                                                                            @IdUsuario={idUsuario}").ToListAsync();
        }
        /// <summary>
        /// Obtener datos de tiempo de repuesta de encuestas
        /// </summary>
        /// <param name="id"> Identificador de encuesta</param>
        /// <param name="idUsuario">Identificador de usuario</param>
        /// <returns></returns>
        [HttpGet("GetEncuestasTiempo/{id},{idUsuario}")]
        public async Task<IEnumerable<EncuestasTiempoSelec>> GetEncuestasTiempo(int id, int idUsuario)
        {
            var et = await _context.Set<EncuestasTiempoSelec>().FromSqlInterpolated($@"EXEC SPR_EncuestasTiempoSeleccionar @IdEncuesta={id}, @IdUsuario={idUsuario}").ToListAsync();
            
            return et;
        }

        // PUT: api/Encuestas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncuestas(int id, Encuestas encuestas)
        {
            if (id != encuestas.IdEncuesta)
            {
                return BadRequest();
            }

            _context.Entry(encuestas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncuestasExists(id))
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

        // POST: api/Encuestas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Encuestas>> PostEncuestas(Encuestas encuestas)
        {
          if (_context.Encuestas == null)
          {
              return Problem("Entity set 'SuerveyAPIContext.Encuestas'  is null.");
          }
            _context.Encuestas.Add(encuestas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEncuestas", new { id = encuestas.IdEncuesta }, encuestas);
        }

        // DELETE: api/Encuestas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncuestas(int id)
        {
            if (_context.Encuestas == null)
            {
                return NotFound();
            }
            var encuestas = await _context.Encuestas.FindAsync(id);
            if (encuestas == null)
            {
                return NotFound();
            }

            _context.Encuestas.Remove(encuestas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EncuestasExists(int id)
        {
            return (_context.Encuestas?.Any(e => e.IdEncuesta == id)).GetValueOrDefault();
        }
    }
}
