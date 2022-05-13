using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Data
{
    /// <summary>
    /// Clase para el control de la relación entre preguntas y respuestas
    /// </summary>
    public class CtrlPreguntaRespuesta
    {
        [Key]
        public int IdCtrlPreguntaRespuesta { get; set; }
        [Required]
        public int IdPregunta { get; set; }
        public Preguntas? Preguntas { get; set; }
        [Required]
        public int IdRespuesta { get; set; }
        public Respuestas? Respuestas { get; set; }
        [Required]
        public bool? IsRespuesta { get; set; }
        [Required]
        public int Orden { get; set; }
        public int IdAgrego { get; set; }
        public DateTime FechaAgrego { get; set; }
        public int IdModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
