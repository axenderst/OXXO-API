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
    public class SchedulerController : Controller
    {
        [HttpPost("GetSchedule")]
        /// <summary>
        /// Este Método devuelve la hora de Inicio y Fin en que se encuentra habilitada la API.
        /// Para acceder a este método, se debe enviar un post request a: http://localhost:52766/api/Scheduler/GetSchedule
        /// La petición no debe contener ningún parámetro
        /// </summary>
        /// <returns>IActionResult Json con ---------------</returns>       
        public IActionResult ObtenHorario()
        {
            var header = Request.Headers["Authorization"].ToString();
            header = header.ToString().Substring("Bearer ".Length).Trim();
            var ArrHeader = header.Split(".");
            var payload = ArrHeader[1].ToString();

            /*Inicia la Validación de la petición: */
            bool valida;

            valida = new Validaciones().EjecutaValidacion(payload, "Get Schedule");
            if (valida)
            {
                try
                {
                    using (var context = new Oxxo2.DataAccess.OxxoContext())
                    {
                        var Sch = context.Scheduler.FromSql("spGetSchedule").ToList();
                        string horarioInicio = Sch.ElementAt(0).horainicio.ToString();
                        string horarioFin = Sch.ElementAt(0).horaFin.ToString();

                        if (Sch.Count > 0)
                        {
                            return Ok("La hora de Inicio es: " + horarioInicio + " y la hora de Finalización es: "+ horarioFin);
                        }
                        else
                        {
                            return BadRequest("No se encontró ningún horario establecido");
                        }
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            else
            {
                return BadRequest("La petición no es válida");
            }

            /*Finaliza la Validación de la petición */
        }


        [HttpPost("UpdSchedule")]
        /// <summary>
        /// Este Método registra nuevas horas de Inicio y Fin para la Utilización del API.
        /// Para acceder a este método, se debe enviar un post request a: http://localhost:52766/api/Scheduler/UpdSchedule
        /// La petición debe contener Hora de Inicio, Hora de Fin y Usuario que solicita.
        /// El formato de la petición debe ser el siguiente: 
        /// {"HoraInicio": "05:00:00", 	"HoraFin": "05:00:00",	"usr": "Usuario desde API" }
    /// </summary>
    /// <returns>IActionResult Json con respuesta de éxito o error</returns>       
    public IActionResult ActualizaHorario([FromBody] SchedulerJson horario)
        {
            var header = Request.Headers["Authorization"].ToString();
            header = header.ToString().Substring("Bearer ".Length).Trim();
            var ArrHeader = header.Split(".");
            var payload = ArrHeader[1].ToString();

            /*Inicia la Validación de la petición: */
            bool valida;

            valida = new Validaciones().EjecutaValidacion(payload, "UpdSchedule");
            if (valida)
            {
                try
                {
                    using (var context = new Oxxo2.DataAccess.OxxoContext())
                    {
                        TimeSpan hrIn = TimeSpan.Parse(horario.HoraInicio);
                        TimeSpan hrFn = TimeSpan.Parse(horario.HoraFin);
                        var Sch = context.Scheduler.FromSql("spInsSchedule @p0, @p1, @p2",
                            hrIn, hrFn, horario.usr).ToList();
                        string horarioInicio = Sch.ElementAt(0).horainicio.ToString();
                        string horarioFin = Sch.ElementAt(0).horaFin.ToString();


                        if (Sch.Count > 0)
                        {
                            return Ok("La nueva hora de Inicio es: " + horarioInicio + " y la nueva hora de Finalización es: " + horarioFin);
                        }
                        else
                        {
                            return BadRequest("No se encontró ningún horario establecido");
                        }
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            else
            {
                return BadRequest("La petición no es válida");
            }

            /*Finaliza la Validación de la petición */
        }


        [HttpPost("GetScheduleInit")]
        /// <summary>
        /// Este Método devuelve la hora de Inicio y Fin en que se encuentra habilitada la API.
        /// Para acceder a este método, se debe enviar un post request a: http://localhost:52766/api/Scheduler/GetSchedule
        /// La petición no debe contener ningún parámetro
        /// </summary>
        /// <returns>IActionResult Json con ---------------</returns>       
        public IActionResult ObtenHorarioInicial()
        {
            var header = Request.Headers["Authorization"].ToString();
            header = header.ToString().Substring("Bearer ".Length).Trim();
            var ArrHeader = header.Split(".");
            var payload = ArrHeader[1].ToString();

            /*Inicia la Validación de la petición: */
            bool valida;

            valida = new Validaciones().EjecutaValidacion(payload, "Get Schedule");
            if (valida)
            {
                try
                {
                    using (var context = new Oxxo2.DataAccess.OxxoContext())
                    {
                        var Sch = context.Scheduler.FromSql("spGetSchedule").ToList();
                        string horarioInicio = Sch.ElementAt(0).horainicio.ToString();
                        string horarioFin = Sch.ElementAt(0).horaFin.ToString();

                        if (Sch.Count > 0)
                        {
                            return Ok(horarioInicio);
                        }
                        else
                        {
                            return BadRequest("No se encontró ningún horario establecido");
                        }
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            else
            {
                return BadRequest("La petición no es válida");
            }

            /*Finaliza la Validación de la petición */
        }

        [HttpPost("GetScheduleEnd")]
        /// <summary>
        /// Este Método devuelve la hora de Inicio y Fin en que se encuentra habilitada la API.
        /// Para acceder a este método, se debe enviar un post request a: http://localhost:52766/api/Scheduler/GetSchedule
        /// La petición no debe contener ningún parámetro
        /// </summary>
        /// <returns>IActionResult Json con ---------------</returns>       
        public IActionResult ObtenHorarioFinal()
        {
            var header = Request.Headers["Authorization"].ToString();
            header = header.ToString().Substring("Bearer ".Length).Trim();
            var ArrHeader = header.Split(".");
            var payload = ArrHeader[1].ToString();

            /*Inicia la Validación de la petición: */
            bool valida;

            valida = new Validaciones().EjecutaValidacion(payload, "Get Schedule");
            if (valida)
            {
                try
                {
                    using (var context = new Oxxo2.DataAccess.OxxoContext())
                    {
                        var Sch = context.Scheduler.FromSql("spGetSchedule").ToList();
                        string horarioInicio = Sch.ElementAt(0).horainicio.ToString();
                        string horarioFin = Sch.ElementAt(0).horaFin.ToString();

                        if (Sch.Count > 0)
                        {
                            return Ok(horarioFin);
                        }
                        else
                        {
                            return BadRequest("No se encontró ningún horario establecido");
                        }
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e);
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