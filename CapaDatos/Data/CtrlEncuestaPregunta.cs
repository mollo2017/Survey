using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Data
{
    /// <summary>
    /// Clase para control entre encuestas y preguntas
    /// </summary>
    public class CtrlEncuestaPregunta
    {
        [Key]
        public int IdCtrlEncuestaPregunta { get; set; }
        [Required]
        public int IdEncuesta { get; set; }
        public Encuestas? Encuestas { get; set; }
        [Required]
        public int IdPregunta { get; set; }
        public Preguntas? Preguntas { get; set; }
        public int IdAgrego { get; set; }
        public DateTime FechaAgrego { get; set; }
        public int IdModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
