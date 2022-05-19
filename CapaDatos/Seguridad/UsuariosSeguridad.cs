using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Seguridad
{
    public class UsuariosSeguridad
    {
        [Key]
        public int IdUsuariosSeguridad { get; set; }
        public byte[]? Llave { get; set; }
        public byte[]? ContraseniaHash { get; set; }
        public int IdUsuario { get; set; }
        public Usuarios? Usuarios { get; set; }
        public int IdAgrego { get; set; }
        public DateTime FechaAgrego { get; set; }
        public int IdModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
