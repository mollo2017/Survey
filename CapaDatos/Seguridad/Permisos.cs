using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Seguridad
{
    /// <summary>
    /// Clase de permisos de acciones por perfil
    /// </summary>
    public class Permisos
    {
        [Key]
        public int IdPermiso { get; set; }
        [Required]
        public int IdPerfil { get; set; }
        public Perfiles? Perfiles { get; set; }
        [Required]
        public int IdAccion { get; set; }
        public Acciones? Acciones { get; set; }
        public int IdAgrego { get; set; }
        public DateTime FechaAgrego { get; set; }
        public int IdModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
