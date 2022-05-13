using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Data
{
    internal class RegistroPreguntaRespuesta
    {
        [Key]
        public int IdRegistroPreguntaRespuesta { get; set; }
        [Required]
        public int IdRegistroUsuarioEncuesta { get; set; }
        public RegistroUsuarioEncuesta? RegistroUsuarioEncuesta { get; set; }
        [Required]
        public int IdPregunta { get; set; }
        public Preguntas? Preguntas { get; set; }
        [Required]
        public int IdRespuesta { get; set; }
        public Respuestas? Respuestas { get; set; }
        public int IdAgrego { get; set; }
        public DateTime FechaAgrego { get; set; }
        public int IdModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
