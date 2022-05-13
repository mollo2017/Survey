using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Data
{
    /// <summary>
    /// Clase de registro de inicio y fin de encuesta
    /// </summary>
    public class RegistroEncuesta
    {
        [Key]
        public int IdRegistroEncuesta { get; set; }
        [Required]
        public string RegistoEvento { get; set; } = String.Empty;
        [Required]
        public int IdRegistroUsuarioEncuesta { get; set; }
        public RegistroUsuarioEncuesta? RegistroUsuarioEncuesta { get; set; }
        [Required]
        public DateTime TiempoRegistro { get; set; }
        public int IdAgrego { get; set; }
        public DateTime FechaAgrego { get; set; }
        public int IdModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
