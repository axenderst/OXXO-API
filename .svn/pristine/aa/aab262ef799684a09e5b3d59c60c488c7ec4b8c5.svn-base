using Microsoft.EntityFrameworkCore;
using Oxxo2.Controllers.Clases;
using Oxxo2.Models;
using System;
using Microsoft.AspNetCore.Mvc;


using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Authorization;

namespace Oxxo2.Controllers
{
    public class Validaciones
    {
        public bool EjecutaValidacion(string TokenCredential, string actividad )
        {
            try
            {
                // Validar Enable Status
                Boolean EnableVal;
                EnableVal = new EnableStats().CheckAvailability();

                if (!EnableVal)
                {
                    return false;
                }
 
                // Validar Scheduling
                bool timerVal;
                timerVal = new Scheduler().Valida();

                if (!timerVal)
                {
                    return false;
                }

                // Validar Permisos Usuario
                bool AuthUsr;
                AuthUsr = new Autorizacion().ValidaPermisos("admin"); // Aquí se pasa el usuario

                if (!AuthUsr)
                {
                    return false;
                }

    //  Validación General

                if (EnableVal && timerVal && AuthUsr)
                {
                    try
                    {
                        using (var context = new Oxxo2.DataAccess.OxxoContext())
                        {
                            // Registro en Bitácora
                            var bitacora = context.Monitor.FromSql("spInsbtMonitor @p0, @p1", TokenCredential, actividad).ToList();

                        }
                    }
                    catch
                    {
                        return false;
                    }

                            return true;
                }
                else
                {
                    //Incluir aquí el Insert para la Bitácora
                    return false;
                }

          
               

            }
            catch (Exception e)
            {
                return false;
            }
           
          


        }



    }


}
