using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Seguridad
{
    /// <summary>
    /// Clase de Perfiles
    /// </summary>
    public class Perfiles
    {
        [Key]
        public int IdPerfil { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        public int IdAgrego { get; set; }
        public DateTime FechaAgrego { get; set; }
        public int IdModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
