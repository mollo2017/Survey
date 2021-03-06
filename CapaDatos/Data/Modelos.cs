using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Data
{
    public class Modelos
    {
    }
    /// <summary>
    /// Modelo base para control de inserciones y modificaciones de registros
    /// </summary>
    public class timeStampModel
    {
        public int IdAgrego { get; set; }
        public DateTime FechaAgrego { get; set; }
        public int IdModifico { get; set; }
        public DateTime FechaModifico { get; set; }
    }
    /// <summary>
    /// Modelo para obtención de datos de encuestas contestadas
    /// </summary>
    public class EncuestaSelect : timeStampModel
    {
        public int IdEncuesta { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Estatus { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; } = string.Empty;
    }
    /// <summary>
    /// Modelo para obtención de datos de tiempo de respuesta de encuestas
    /// </summary>
    public class EncuestasTiempoSelec
    {
        public int IdEncuesta { get; set; }
        public string Encuesta { get; set; } = string.Empty;
        public string TiempoEncuesta { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
        public string Usuario { get; set; } = string.Empty;
    }
    /// <summary>
    /// Modelo para obtención de datos de resultados de pregunta por encuesta
    /// </summary>
    public class PreguntasResultadoSelect
    {
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; } = string.Empty;
        public string Resultado { get; set; } = string.Empty;
    }
    /// <summary>
    /// Modelo para obtención de datos de preguntas por encuesta
    /// </summary>
    public class PreguntasSelect : timeStampModel
    {
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; } = string.Empty;
    }
    /// <summary>
    /// Modelo para obtención de datos de tiempo por preguntapor por encuesta
    /// </summary>
    public class PreguntasTiempoSelect
    {
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; } = string.Empty;
        public string TiempoRespuesta { get; set; } = string.Empty;
    }
    /// <summary>
    /// Modelo para obtener datos de respuestas pertenecientes a preguntas
    /// </summary>
    public class RespuestasSelect : timeStampModel
    {
        public int IdRespuesta { get; set; }
        public string Respuesta { get; set; } = string.Empty;
        public bool IsRespuesta { get; set; }
        public int Orden { get; set; }
    }
    /// <summary>
    /// Clase para verificar la contraseña hash en BD
    /// </summary>
    public class AccesoUsuarioToken
    {
        public bool Acceso { get; set; }
        public DateTime FechaExpira { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
    /// <summary>
    /// Clase para obtener datos de login
    /// </summary>
    public class UsuarioSeguridad
    {
        public string correo { get; set; } = string.Empty;
        public string contrasenia { get; set; } = string.Empty;
    }
    /// <summary>
    /// Clase para controlar la consulta de llave a la BD
    /// </summary>
    public class UsrSegToken
    {
        public bool Acceso { get; set; }
        public string Llave { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public int Codigo { get; set; }
    }
    /// <summary>
    /// Clase para retornar el resultado de login
    /// </summary>
    public class Tokenlogin
    {
        public Tokenlogin(bool _Acceso, string _Token, string _ErrorCode, string _MsgError)
        {
            this.Acceso = _Acceso;
            this.Token = _Token;
            this.ErrorCode = _ErrorCode;
            this.MsgError = _MsgError;
        }
        public bool Acceso { get; set; }
        public string Token { get; set; } = string.Empty;
        public string ErrorCode { get; set; } = string.Empty;
        public string MsgError { get; set; } = string.Empty;
    }
}
