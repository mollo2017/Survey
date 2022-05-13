using CapaDatos.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Data
{
    /// <summary>
    /// Clase para registrar las encuestas realizadas por el usuario
    /// </summary>
    public class RegistroUsuarioEncuesta
    {
        [Key]
        public int IdRegistroUsuarioEncuesta { get; set; }
        [Required]
        public int IdEncuesta { get; set; }
        public Encuestas? Encuestas { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        public Usuarios? Usuarios { get; set; }
        public int IdAgrego { get; set; }
        public DateTime FechaAgrego { get; set; }
        public int IdModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
