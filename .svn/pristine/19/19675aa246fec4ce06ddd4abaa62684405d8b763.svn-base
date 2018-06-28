using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Oxxo2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EnableController : Controller
    {
        [HttpPost("CheckStatus")]
        /// <summary>
        /// Este Método realiza la verificación del estatus de la API.
        /// Para acceder a este método, se debe enviar un post request a: http://localhost:52766/api/Enable/CheckStatus
        /// La petición no necesita parámetros.
        /// </summary>
        /// <returns>IActionResult Json con 1= Éxito en la transacción, 0=No exito</returns>       
        public IActionResult CheckStatus()
        {             

            try
            {

                    using (var context = new Oxxo2.DataAccess.OxxoContext())
                    {
                        var BtEnableStatus = context.Enabled.FromSql("spGetEnableStatus").ToList();
                    bool stats = BtEnableStatus.ElementAt(0).IsActive;
                        if (stats)
                        {
                            return Ok("1"); //El estatus es Habilitado
                        }
                        else
                        {
                            return Ok("0"); // El estatus es Inhabilitado
                        }
                    }

                }
                catch
                {
                    return BadRequest("0"); //("No se ha podido llevar a cabo la transacción");
                }

        } //End CheckStatus


        [HttpPost("Disable")]
        /// <summary>
        /// Este Método realiza la Desactivación de la API por completo.
        /// Para acceder a este método, se debe enviar un post request a: http://localhost:52766/api/Enable/Disable
        /// La petición deberá contener una cadena con el Valor de Usuario.
        /// "Usuario"
        /// </summary>
        /// <returns>IActionResult Json con 1= Éxito en la transacción, 0=No exito</returns>       
        public IActionResult Disable([FromBody] string usuario)
        {
            var header = Request.Headers["Authorization"].ToString();
            header = header.ToString().Substring("Bearer ".Length).Trim();
            var ArrHeader = header.Split(".");
            var payload = ArrHeader[1].ToString();


            bool valida;

            valida = new Validaciones().EjecutaValidacion(payload, "DisableAPI");
            if (valida)
            {
                try
                {

                    using (var context = new Oxxo2.DataAccess.OxxoContext())
                    {
                        var BtEnableStatus = context.Enabled.FromSql("spInsDisableStatus @p0", usuario).ToList();
                       
                        if (BtEnableStatus.Count > 0)
                        {
                            return Ok("1"); // ("La actualización se realizó correctamente");
                        }
                        else
                        {
                            return BadRequest("0"); //("No se ha llevado a cabo la actualización");
                        }
                    }

                }
                catch
                {
                    return BadRequest("0"); //("No se ha podido llevar a cabo la transacción");
                }
            }
            return BadRequest("0"); //("Petición No válida");
        } //End Disable

        
        [HttpPost("Enable")]
        /// <summary>
        /// Este Método realiza la activación de la API por completo.
        /// Para acceder a este método, se debe enviar un post request a: http://localhost:52766/api/Enable/Enable
        /// La petición debe contener una cadena con valor Usuario.
        /// "Usuario"
        /// </summary>
        /// <returns>IActionResult Json con 1= Éxito en la transacción, 0=No exito</returns>       
        public IActionResult Enable([FromBody] string usuario)
        {          
                try
                {

                    using (var context = new Oxxo2.DataAccess.OxxoContext())
                    {
                        var BtEnableStatus = context.Enabled.FromSql("spInsEnableStatus @p0", usuario).ToList();
                        if (BtEnableStatus.Count > 0)
                        {
                            return Ok("1"); // Transacción exitosa
                        }
                        else
                        {
                            return BadRequest("0"); // Transacción no exitosa
                        }
                    }

                }
                catch
                {
                    return BadRequest("0"); //No se pudo llevar a cabo la transacción
                }
            
        } /*End Enable()*/



    } /* End EnableController*/
} /*End Namespace*/