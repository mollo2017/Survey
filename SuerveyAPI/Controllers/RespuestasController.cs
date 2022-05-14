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
    public class RespuestasController : ControllerBase
    {
        private readonly SuerveyAPIContext _context;

        public RespuestasController(SuerveyAPIContext context)
        {
            _context = context;
        }

        // GET: api/Respuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Respuestas>>> GetRespuestas()
        {
          if (_context.Respuestas == null)
          {
              return NotFound();
          }
            return await _context.Respuestas.ToListAsync();
        }

        /// <summary>
        /// Obtener datos de respuestas por pregunta
        /// </summary>
        /// <param name="idRespuesta">Identificador de respuesta</param>
        /// <param name="idPregunta">Identificador de pregunta</param>
        /// <returns></returns>
        [HttpGet("GetRespuestasPorPregunta/{idRespuesta},{idPregunta}")]
        public async Task<IEnumerable<RespuestasSelect>> GetRespuestasPorPregunta(int? idRespuesta, int? idPregunta)
        {
            return await _context.Set<RespuestasSelect>().FromSqlInterpolated($@"EXEC SPR_RespuestasSeleccionar 
                                                                            @IdRespuesta={idRespuesta},
                                                                            @IdPregunta={idPregunta}").ToListAsync();
        }

        // GET: api/Respuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Respuestas>> GetRespuestas(int id)
        {
          if (_context.Respuestas == null)
          {
              return NotFound();
          }
            var respuestas = await _context.Respuestas.FindAsync(id);

            if (respuestas == null)
            {
                return NotFound();
            }

            return respuestas;
        }

        // PUT: api/Respuestas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRespuestas(int id, Respuestas respuestas)
        {
            if (id != respuestas.IdRespuesta)
            {
                return BadRequest();
            }

            _context.Entry(respuestas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RespuestasExists(id))
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

        // POST: api/Respuestas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Respuestas>> PostRespuestas(Respuestas respuestas)
        {
          if (_context.Respuestas == null)
          {
              return Problem("Entity set 'SuerveyAPIContext.Respuestas'  is null.");
          }
            _context.Respuestas.Add(respuestas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRespuestas", new { id = respuestas.IdRespuesta }, respuestas);
        }

        // DELETE: api/Respuestas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRespuestas(int id)
        {
            if (_context.Respuestas == null)
            {
                return NotFound();
            }
            var respuestas = await _context.Respuestas.FindAsync(id);
            if (respuestas == null)
            {
                return NotFound();
            }

            _context.Respuestas.Remove(respuestas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RespuestasExists(int id)
        {
            return (_context.Respuestas?.Any(e => e.IdRespuesta == id)).GetValueOrDefault();
        }
    }
}
