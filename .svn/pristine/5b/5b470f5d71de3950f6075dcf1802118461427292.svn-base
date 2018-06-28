using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Oxxo2.Controllers
{
    /// <Sumary> 
    /// Este método se utiliza para obtener la lista de Proveedores
    /// Para acceder a esta funcionalidad de la API, llamar: http://localhost:52766/api/proveedores/listaProveed
    /// <Sumary/>
    /// <param name="ListaProveedores"></param>
    /// <returns>Json con Lista de Proveedores</returns>
    [Authorize]
    [Route("api/[controller]")]    
    public class ProveedoresController : Controller
    {
        [HttpPost("listaProveed")] // Para acceder a esta funcionalidad de la API, llamar: http://localhost:52766/api/proveedores/listaProveed

        public IActionResult ListaProveedores()
        {
            var header = Request.Headers["Authorization"].ToString();
            header = header.ToString().Substring("Bearer ".Length).Trim();
            var ArrHeader = header.Split(".");
            var payload = ArrHeader[1].ToString();

            // Aquí ingresar la validación del Scheduler:
            bool validaciones;
            validaciones = new Validaciones().EjecutaValidacion(payload, "Lista Proveedores");
            if (validaciones)
            { 
            // falta mandar a llamar la validación del TOKEN

                try
                {
                    using (var context = new Oxxo2.DataAccess.OxxoContext())
                    {
                        var proveed = context.Proveedor.ToList();
                        return Ok(proveed);
                    }

                } catch(Exception e)
                {
                    return BadRequest(e);
                }

            }
            else
            {
                return BadRequest("La petición no es válida");

            }


        }

    }
}
