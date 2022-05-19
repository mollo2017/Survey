using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapaDatos.Seguridad;
using SuerveyAPI.Data;
using CapaDatos;
using CapaDatos.Data;
using SuerveyAPI.Utils_Code;

namespace SuerveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly SuerveyAPIContext _context;

        public UsuariosController(SuerveyAPIContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarios(int id)
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            var usuarios = await _context.Usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(int id, Usuarios usuarios)
        {
            if (id != usuarios.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        /// <summary>
        /// Método para dar de alta un usuario
        /// </summary>
        /// <param name="usuarios">Objeto con datos de alta</param>
        /// <returns>El objeto usuario creado</returns>
        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IEnumerable<Usuarios>> PostUsuarios(Usuarios usuarios)
        {
            string Llave = string.Empty;
            string ContraseniaHash = string.Empty;
            Utils.MtdObtenerHash(usuarios.Contrasenia, out Llave, out ContraseniaHash);

            return await _context.Set<Usuarios>().FromSqlInterpolated($@"EXEC SPR_UsuariosInsertar
                                                                            @IdUsuario={usuarios.IdUsuario},
                                                                            @Nombre={usuarios.Nombre},
                                                                            @Apaterno={usuarios.Apaterno},
                                                                            @Amaterno={usuarios.Amaterno},
                                                                            @Correo={usuarios.Correo},
                                                                            @Contrasenia={usuarios.Contrasenia},
                                                                            @Estatus={usuarios.Estatus},
                                                                            @IdPerfil={usuarios.IdPerfil},
                                                                            @Llave={Llave},
                                                                            @ContraseniaHash={ContraseniaHash}").ToListAsync();
        }

        /// <summary>
        /// Método de para el login con implementación de JWT
        /// </summary>
        /// <param name="usr">Objeto con correo y contraseña de quien solicita el login</param>
        /// <returns>Objeto de login que contiene el token en caso de ser correcto de lo contrario retorna mensaje</returns>

        [HttpPost("login")]
        public async Task<ActionResult<Tokenlogin>> Login(UsuarioSeguridad usr)
        {
            //Consulta si existe el usuario para las credenciales ingresadas y obtiene la llave para hacer el hash a la contraseña
            var llaveHash = _context.Set<UsrSegToken>().FromSqlInterpolated($@"EXEC SPR_UsuariosVerificaHash
                                                                            @Correo={usr.correo},
                                                                            @Contrasenia={usr.contrasenia}").AsAsyncEnumerable();

            string Llave = string.Empty;

            if (llaveHash.GetAsyncEnumerator == null)
                return new Tokenlogin(false, "", "3", ApiConst.usuarioContrasenia);

            await foreach (UsrSegToken ust in llaveHash)
            {
                bool ac = ust.Acceso;
                if (ust.Acceso)
                    Llave = ust.Llave;
                else
                    return new Tokenlogin(ust.Acceso, "", ust.Codigo.ToString(), ust.Mensaje);
            }
            //Consulta la contraseña en hash que sea correcta
            string ContraseniaHash = string.Empty;
            Utils.MtdObtenerContraseniaHash(usr.contrasenia, Llave, out ContraseniaHash);
            var res = _context.Set<AccesoUsuarioToken>().FromSqlInterpolated($@"EXEC SPR_UsuariosLogin
                                                                            @Correo={usr.correo},
                                                                            @Contrasenia={usr.contrasenia},
                                                                            @Llave={Llave},
                                                                            @ContraseniaHash={ContraseniaHash}").AsAsyncEnumerable();
            await foreach (AccesoUsuarioToken uct in res)
            {
                bool ac = uct.Acceso;
                if (ac)
                {
                    return new Tokenlogin(ac, Utils.MtdCrearToken(uct.FechaExpira, uct.Nombre, Llave), "0", "");
                }
                else
                    return new Tokenlogin(ac, "", "2", ApiConst.contraseniaIncorrecta);
            }

            return new Tokenlogin(false, "", "1000", ApiConst.errorDatos);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarios(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuariosExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}
