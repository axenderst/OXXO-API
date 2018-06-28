using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oxxo2.Models;

namespace Oxxo2.Controllers
{
    public class Scheduler
    {

        public bool Valida()
        {

            string HoraPeticion =DateTime.Now.ToString("hh:mm:ss");
            var hour = DateTime.Now.Hour.ToString();
            var min = DateTime.Now.Minute.ToString();
            var sec = DateTime.Now.Second.ToString();

            hour = FixTime(hour);
            min = FixTime(min);
            sec = FixTime(sec);
            var horario = Int32.Parse(hour + min + sec); // Obtenemos el horario en formato Militar

            
            using (var context = new Oxxo2.DataAccess.OxxoContext())
            {
                // Schedulers horario = new Schedulers();

                var Sch = context.Scheduler.FromSql("spGetSchedule").ToList(); // Consultamos mediante SP el Schedule activo más reciente
                string horarioInicio = Sch.ElementAt(0).horainicio.ToString(); 
                string horarioFin = Sch.ElementAt(0).horaFin.ToString();   
                
                var hora_ini = horarioInicio.Split(':').First();
                var min_ini = horarioInicio.Split(':').ElementAt(1);
                var seg_ini = horarioInicio.Split(':').ElementAt(2);
                var horario_inicio = Int32.Parse(hora_ini + min_ini + seg_ini); // Horario Militar (Inicio)

                var hora_fin = horarioFin.Split(':').First();
                var min_fin = horarioFin.Split(':').ElementAt(1);
                var seg_fin = horarioFin.Split(':').ElementAt(2);
                var horario_fin = Int32.Parse(hora_fin + min_fin + seg_fin); //Horario Militar(Fin)

                if (horario_inicio == horario_fin)
                {
                    //pasa de corrido porque significa que las 24 horas son validas.
                    return true;
                } else if (horario_inicio < horario_fin)
                {
                    //aqui estamos en el mismo día:
                    if (horario >= horario_inicio && horario <= horario_fin)
                    {
                        //aqui pasa porque el horario cae dentro del rango
                        return true;
                    }
                    else
                    {
                        // aqui no pasa porque cae fuera del rango
                        return false;
                    }
                } else
                {
                    //aqui estamos en dia siguiente
                    if ((horario <= horario_inicio && horario <= horario_fin )|| (horario >= horario_inicio && horario >= horario_fin))
                    {
                        //aqui cae dentro del rango y pasa
                        return true;
                    } else
                    {
                        //aqui cae fuera del rango y no pasa
                        return true;
                    }
                }

                      

            }
    }





        public IActionResult OutOfOrder()
        {
            return Respuesta("No se encontraron Inventarios sin Completar");
            
        }

        private IActionResult Respuesta(string v)
        {
            throw new NotImplementedException();
        }

        public string FixTime(string time)
        {
            while (time.Length < 2)
            {
                time = '0' + time;
            }
            return time;
        }



    }

    
}