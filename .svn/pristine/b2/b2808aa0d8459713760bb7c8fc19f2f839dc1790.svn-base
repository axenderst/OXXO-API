using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oxxo2.Models;

namespace Oxxo2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class MonitorController : Controller
    {
        [HttpPost("lista")]
        /// <Sumary> 
        /// Este método se utiliza para obtener la lista completa de la tabla de monitoreo de transacciones.
        /// Para acceder a esta funcionalidad de la API, llamar: http://localhost:52766/api/Monitor/lista
        /// 
        /// <Sumary/>
        /// <param name="ListaMonitor"></param>
        /// <returns>Json con la Lista de Actividades realizadas</returns>
        public IActionResult ListaMonitor()
        {
            var header = Request.Headers["Authorization"].ToString();
            header = header.ToString().Substring("Bearer ".Length).Trim();
            var ArrHeader = header.Split(".");
            var payload = ArrHeader[1].ToString();

            /*Inicia la Validación de la petición: */
            bool valida;

            valida = new Validaciones().EjecutaValidacion(payload, "Lista Monitor");
            if (valida)
            {
                try
                {
                    using (var context = new Oxxo2.DataAccess.OxxoContext())
                    {
                        var ListaMonitoreo = context.Monitor.FromSql("spGetMonitoreo").ToList();
                        int tamanio = ListaMonitoreo.Count();
                        int cntFor = 0;
                        string ListaFinal = "{ \"data\": [";
                        foreach (var item in ListaMonitoreo)
                        {
                            cntFor++;
                            ListaFinal = ListaFinal + "[\"" + item.MonitorId + "\",";
                            ListaFinal = ListaFinal + "\"" + item.Usuario + "\",";
                            ListaFinal = ListaFinal + "\"" + item.timestamp + "\",";
                            ListaFinal = ListaFinal + "\"" + item.Actividad + "\"]";

                            if (tamanio > cntFor)
                                ListaFinal = ListaFinal + ",";
                        }
                        ListaFinal = ListaFinal + "]}";


                        if (tamanio > 0)
                        {
                            return Ok(ListaFinal);
                        }
                        else
                        {
                            return BadRequest("No se encontraron Transacciones en la Lista de Monitoreo");
                        }
                    }
                }
                catch (Exception e)
                {
                    return BadRequest("La solicitud de Lista de monitoreo no pudo llevarse a cabo, debido al error: " + e);
                }
            }
            else
            {
                return BadRequest("La petición no es válida");
            }

            /*Finaliza la Validación de la petición */
            
        }



        [HttpPost("MonitorUsr")]
        /// <Sumary> 
        /// Este método se utiliza para obtener la lista de transacciones por Usuario
        /// Para acceder a esta funcionalidad de la API, llamar: http://localhost:52766/api/Monitor/lista
        /// 
        /// <Sumary/>
        /// <param name="MonitorUsr"></param>
        /// <returns>Json con la Lista de Actividades realizadas</returns>
        public IActionResult MonitorUsr([FromBody]Monitoreo usr)
        {
            var header = Request.Headers["Authorization"].ToString();
            header = header.ToString().Substring("Bearer ".Length).Trim();
            var ArrHeader = header.Split(".");
            var payload = ArrHeader[1].ToString();

            /*Inicia la Validación de la petición: */
            bool valida;

            valida = new Validaciones().EjecutaValidacion(payload, "Monitor Usr");
            if (valida)
            {
                try
                {
                    using (var context = new Oxxo2.DataAccess.OxxoContext())
                    {
                        var ListaMonitoreo = context.Monitor.FromSql("spGetEncabezadoInventario @p0", usr.Usuario).ToList();
                        if (ListaMonitoreo.Count > 0)
                        {
                            return Ok(ListaMonitoreo);
                        }
                        else
                        {
                            return BadRequest("No se encontraron Transacciones en la Lista de Monitoreo");
                        }
                    }
                }
                catch (Exception e)
                {
                    return BadRequest("La solicitud de Lista de monitoreo no pudo llevarse a cabo, debido al error: " + e);
                }
            }
            else
            {
                return BadRequest("La petición no es válida");
            }

            /*Finaliza la Validación de la petición */

            
        }

    }
}