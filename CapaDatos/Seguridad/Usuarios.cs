using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Seguridad
{
    /// <summary>
    /// Clase de Usuarios
    /// </summary>
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Aparterno { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Amaterno { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Correo { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Contrasenia { get; set; } = string.Empty;
        [Required]
        public bool Estatus { get; set; }
        [Required]
        public int IdPerfil { get; set; }
        public Perfiles? Perfiles { get; set; }
        public int IdAgrego { get; set; }
        public DateTime FechaAgrego { get; set; }
        public int IdModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
