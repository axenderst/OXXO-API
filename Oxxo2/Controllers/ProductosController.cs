using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oxxo2.Models;
using System;
using System.Linq;

namespace Oxxo2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        [HttpPost("listaProductos")]
        /// <Sumary> 
        /// Este método se utiliza para obtener la lista de productos de un proveedor en específico.
        /// Para acceder a esta funcionalidad de la API, llamar: http://localhost:52766/api/productos/listaProductos
        /// Para llamar a este método, se deberá enviar un Json desde el body request del tipo: 
        /// { "ProveedorId": 2   }
        /// <Sumary/>
        /// <param name="ListaProductos"></param>
        /// <returns>Json con la Lista de Productos del proveedor Especificado en Parámetros</returns>
        //
        public IActionResult ListaProductos([FromBody] Proveedores proveed)
        {
            var header = Request.Headers["Authorization"].ToString();
            header = header.ToString().Substring("Bearer ".Length).Trim();
            var ArrHeader = header.Split(".");
            var payload = ArrHeader[1].ToString();

            /*Inicia la Validación de la petición: */
            bool valida;

            valida = new Validaciones().EjecutaValidacion(payload, "Lista Productos");
            if (valida)
            {
                try
                {
                    using (var context = new Oxxo2.DataAccess.OxxoContext())
                    {
                        var productos = context.Producto.FromSql("spGetProdByProveed @p0", proveed.ProveedorId).ToList();
                        if (productos.Count > 0)
                        {
                            return Ok(productos);
                        }
                        else
                        {
                            return BadRequest("No se encontraron Productos del Proveedor Seleccionado");
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
