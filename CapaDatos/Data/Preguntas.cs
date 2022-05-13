using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Data
{
    /// <summary>
    /// Clase de preguntas
    /// </summary>
    public class Preguntas
    {
        [Key]
        public int IdPregunta { get; set; }
        [Required]
        [StringLength(50)]
        public string Pregunta { get; set; } = string.Empty;
        public int IdAgrego { get; set; }
        public DateTime FechaAgrego { get; set; }
        public int IdModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
