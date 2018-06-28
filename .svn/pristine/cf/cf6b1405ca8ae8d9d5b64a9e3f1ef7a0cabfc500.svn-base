using System;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.Linq;

namespace Oxxo2.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        /// <summary>
        /// Función de Autenticación de la API, para comunicarse a esta funcionalidad deberá realizarse un POST request 
        /// a la dirección: 
        /// http://localhost:52766/api/auth/token
        /// Se deberá enviar en el Header de la petición: 
        ///     Authorization: Basic +Encripted(user:pass)
        ///     Content-Type: application/x-www-form-urlencoded
        /// </summary>
        /// <returns>Token String/// </returns>
        [HttpPost("token")]
        public IActionResult Token()
        {                  

            var header = Request.Headers["Authorization"];
            if (header.ToString().StartsWith("Basic"))
                {

                var credValue = header.ToString().Substring("Basic ".Length).Trim();
                var userAndPassEnc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue)); //(user:pass)
                var userAndPass = userAndPassEnc.Split(":");
                                
                using (var context = new Oxxo2.DataAccess.OxxoContext())                
                {
                    var users = context.Usuario.ToList();                    
                    foreach (var user in users)
                    {
                        if (userAndPass[0] == user.Usuario && userAndPass[1] == user.contrasenia)
                        {
                            var claimsdata = new[] { new Claim(ClaimTypes.Name, user.Usuario) };
                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdlasfkasflasjfkasfjlasjfkasfaldsjfalfakjsdf"));//La llave no debe ir aquí, sino en el archivo de configuración, lo ponemos aquí únicamente para fines de desarrollo.
                            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                            var token = new JwtSecurityToken(
                                issuer: "mysite.com",
                                audience: "mysite.com",
                                expires: DateTime.Now.AddMinutes(100),
                                claims: claimsdata,
                                signingCredentials: signInCred
                                );

                            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                            return Ok(tokenString);
                        }

                    }
                    //return View();
                    return BadRequest("The user wasn't found in the Database");
                }



            }
            return BadRequest("Wrong Request");
        }


   





    }
}