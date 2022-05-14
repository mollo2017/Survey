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
        /// <summary>
        /// Obtener datos de resultados de la encuesta
        /// </summary>
        /// <param name="idEncuesta"> Identificador de encuesta</param>
        /// <param name="idUsuario">Identificador de usuario</param>
        /// <returns></returns>
        [HttpGet("GetPreguntasResultados/{idEncuesta},{idUsuario}")]
        public async Task<IEnumerable<PreguntasResultadoSelect>> GetPreguntasResultados(int idEncuesta, int idUsuario)
        {
            return await _context.Set<PreguntasResultadoSelect>().FromSqlInterpolated($@"EXEC SPR_PreguntasResultadoSeleccionar 
                                                                            @IdEncuesta={idEncuesta},
                                                                            @IdUsuario={idUsuario}").ToListAsync();
        }
        /// <summary>
        /// Obtener datos de preguntas por encuesta
        /// </summary>
        /// <param name="idPregunta"> Identificador de pregunta</param>
        /// <param name="idUsuario">Identificador de usuario</param>
        /// <returns></returns>
        [HttpGet("GetPreguntasPorEncuesta/{idPregunta},{idUsuario}")]
        public async Task<IEnumerable<PreguntasSelect>> GetPreguntasPorEncuesta(int idPregunta, int idUsuario)
        {
            return await _context.Set<PreguntasSelect>().FromSqlInterpolated($@"EXEC SPR_PreguntasSeleccionar 
                                                                            @IdPregunta={idPregunta},
                                                                            @IdUsuario={idUsuario}").ToListAsync();
        }

        /// <summary>
        /// Obtener datos de tiempo de respuesta de preguntas contestadas
        /// </summary>
        /// <param name="idEncuesta"> Identificador de encuesta</param>
        /// <param name="idUsuario">Identificador de usuario</param>
        /// <returns></returns>
        [HttpGet("GetPreguntasTiempo/{idEncuesta},{idUsuario}")]
        public async Task<IEnumerable<PreguntasTiempoSelect>> GetPreguntasTiempo(int idEncuesta, int idUsuario)
        {
            return await _context.Set<PreguntasTiempoSelect>().FromSqlInterpolated($@"EXEC SPR_PreguntasTiempoSeleccionar 
                                                                            @IdEncuesta={idEncuesta},
                                                                            @IdUsuario={idUsuario}").ToListAsync();
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
