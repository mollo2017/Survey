using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Data
{
    /// <summary>
    /// Clase para el registro del tiempo en que se solicita / responde una pregunta
    /// </summary>
    public class RegistroEncuestaPregunta
    {
        [Key]
        public int IdRegistroEncuestaPregunta { get; set; }
        [Required]
        public string RegistoEvento { get; set; } = String.Empty;
        [Required]
        public int IdRegistroUsuarioEncuesta { get; set; }
        public RegistroUsuarioEncuesta? RegistroUsuarioEncuesta { get; set; }
        [Required]
        public DateTime TiempoRegistro { get; set; }
        [Required]
        public int IdPregunta { get; set; }
        [Required]
        public Preguntas? Preguntas { get; set; }
        public int IdAgrego { get; set; }
        public DateTime FechaAgrego { get; set; }
        public int IdModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
