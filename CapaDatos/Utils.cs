using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace CapaDatos
{
    public class Utils
    {
        public static void MtdObtenerHash(string contrasenia, out string Llave, out string ContraseniaHash)
        {
            using (var hmac = new HMACSHA256())
            {
                Llave = Convert.ToBase64String(hmac.Key);
                ContraseniaHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contrasenia)));
            }
        }
        public static void MtdObtenerContraseniaHash(string contrasenia, string Llave, out string ContraseniaHash)
        {
            using (var hmac = new HMACSHA256())
            {
                hmac.Key = Convert.FromBase64String(Llave);
                byte[] con = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contrasenia));
                ContraseniaHash = Convert.ToBase64String(con);
            }
        }
        public static string MtdCrearToken(DateTime dt, string Nombre, string Llave)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Nombre)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Llave));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: dt,
                signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
