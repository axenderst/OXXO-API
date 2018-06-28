using Microsoft.AspNetCore.Mvc;
using Oxxo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Oxxo2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class InventarioController : Controller
    {
        private ICollection<SubListaProductosJson> list;

        [HttpPost("submitInventory")]
        /// <Sumary> 
        /// Este método se utiliza para registrar un Inventario:
        /// - Nuevo con productos seleccionados 
        /// - Con o sin productos
        /// - Finalizado o No finalizado
        /// Para acceder a esta funcionalidad de la API, llamar: http://localhost:52766/api/Inventario/submitInventory
        /// Para llamar a este método, se deberá enviar un Json desde el body request del tipo: 
        //        Nuevo Inventario solo encabezado:
        //{ "InventarioNombre": "Nuevo Inventario Guardar Sin Finalizar", "FolioGoma": "NuevoInvSF001", "Finalizado":false, "InvId": -1 }
        //    Nuevo Inventario con Productos No Finalizado:
        //{ "InventarioNombre": "InventarioFinalizadoDesdeLaApi9", "FolioGoma": "INV-IAPI-009", "Finalizado":false, "InvId": -1,  
        //"ListaDeProductos":[
        //       {"id": 9, "descripcion": "Descripción del producto 9","proveedorId": 3,  "existencia": 500},
        //       {"id": 19,	"descripcion": "Descripción del producto 19",	"proveedorId": 2, "existencia": 250}]	}
        //Nuevo Inventario con productos Finalizado:
        //{ "InventarioNombre": "InventarioFinalizadoDesdeLaApi9", "FolioGoma": "INV-IAPI-009", "Finalizado":true, "InvId": -1,  
        //"ListaDeProductos":[
        //       {"id": 9, "descripcion": "Descripción del producto 9","proveedorId": 3,  "existencia": 500},
        //       {"id": 19,	"descripcion": "Descripción del producto 19",	"proveedorId": 2, "existencia": 250}] }
        //Modificacion de inventario(solo datos) sin finalizar:
        //{ "InventarioNombre": "Inventario modificado desde API", "FolioGoma": "INV-IAPI-555", "Finalizado":false, "InvId": 62 }
        //Modificación de inventario(solo datos) Finalizado:
        //{ "InventarioNombre": "Inventario modificado desde API", "FolioGoma": "INV-IAPI-555", "Finalizado":true,"InvId": 62 }
        //Modif de inventario con producto sin finalizar:
        //{ "InventarioNombre": "Inventario Actualizado", "FolioGoma": "INV-IAPI-009", "Finalizado":false, "InvId": 61,  
        // "ListaDeProductos":[
        //       {"id": 9, "descripcion": "Descripción del producto 9","proveedorId": 3,  "existencia": 500},
        //       {"id": 19,	"descripcion": "Descripción del producto 19",	"proveedorId": 2, "existencia": 250}]	}
        //Modif de Inventario con producto Finalizado:
        //{ "InventarioNombre": "Inventario Actualizado", "FolioGoma": "INV-IAPI-009", "Finalizado":true, "InvId": 61,  
        //"ListaDeProductos":[
        //       {"id": 9, "descripcion": "Descripción del producto 9","proveedorId": 3,  "existencia": 500},
        //       {"id": 19,	"descripcion": "Descripción del producto 19",	"proveedorId": 2, "existencia": 250}]	}
        /// <Sumary/>
        /// <param name="Submit"></param>
        /// <returns>Mensaje de Error y Exito</returns>
        public IActionResult Submit([FromBody]InventarioJson item)
        {
            var header = Request.Headers["Authorization"].ToString();
            header = header.ToString().Substring("Bearer ".Length).Trim();
            var ArrHeader = header.Split(".");
            var payload = ArrHeader[1].ToString();
            /*Inicia la Validación de la petición: */
            bool valida;

            valida = new Validaciones().EjecutaValidacion(payload, "SubmitInventory");
            if (valida)
            {
                bool finalizado = item.Finalizado;
                int InvId = item.InvId;



                if (InvId <= 0) //Es un Inventario Nuevo
                {
                    try
                    {
                        using (var context = new Oxxo2.DataAccess.OxxoContext())
                        {
                            // Registro Inventario
                            var Inventario = context.Inventario.FromSql("spInsInventario @p0, @p1", item.InventarioNombre, item.FolioGoma).ToList();
                            context.SaveChanges();
                            //Si se guardó como finalizado, se finaliza el inventario
                            if (finalizado)
                            {
                                int idInv = Inventario.ElementAt(0).InventarioId;
                                Inventario = context.Inventario.FromSql("spUpdFinalizaInventario @p0", idInv).ToList();
                            }

                            //Si tiene Productos, se realiza el Registro de productos
                            if (item.ListaDeProductos != null)
                            {
                                IEnumerable<SubListaProductosJson> Lista = item.ListaDeProductos;
                                foreach (var producto in Lista)
                                {
                                    var ProductsInvent = context.InventarioProducto.FromSql("spInsProdInventario @p0, @p1, @p2", producto.id, Inventario.ElementAt(0).InventarioId, producto.proveedorId).ToList();
                                }
                            }
                            //Aquí se deberá regresar el algunos valores del Inventario registrado, para mostrarlos en la APP.
                            //return Ok("El inventario con Id:  " + Inventario.ElementAt(0).InventarioId.ToString() + " Fue registrado");
                            return Ok(Inventario);

                        }
                    }
                    catch (Exception e)
                    {
                        return BadRequest("No se registró en la B.D" + e);
                    }

                }
                else
                {
                    //Aquí se va a llamar el registro de modificacion de inventarios
                    try
                    {
                        using (var context = new Oxxo2.DataAccess.OxxoContext())
                        {
                            // Actualización de datos del Inventario
                            var Inventario = context.Inventario.FromSql("spUpdInventario @p0, @p1, @p2", InvId, item.InventarioNombre, item.FolioGoma).ToList();
                            context.SaveChanges();
                            //Si se guardó como finalizado, se finaliza el inventario
                            if (finalizado)
                            {
                                Inventario = context.Inventario.FromSql("spUpdFinalizaInventario @p0", InvId).ToList();
                            }

                            //Si tiene Productos, se realiza el Registro de productos
                            if (item.ListaDeProductos != null)
                            {
                                //primero elimino todos los  productos del Inventario
                                var delProdInv = context.Inventario.FromSql("spDelProductosInv @p0", InvId).ToList();

                                IEnumerable<SubListaProductosJson> Lista = item.ListaDeProductos;
                                foreach (var producto in Lista)
                                {
                                    var ProductsInvent = context.InventarioProducto.FromSql("spInsProdInventario @p0, @p1, @p2", producto.id, Inventario.ElementAt(0).InventarioId, producto.proveedorId).ToList();
                                }
                            }
                            //Aquí se deberá regresar el algunos valores del Inventario registrado, para mostrarlos en la APP.
                            return Ok("El inventario con Id:  " + Inventario.ElementAt(0).InventarioId.ToString() + " Fue actualizado");
                            //return (Inventario);

                        }
                    }
                    catch (Exception e)
                    {
                        return BadRequest("No se registró en la B.D" + e);
                    }
                }

            }
            else
            {
                return BadRequest("La petición no es válida");
            }

            /*Finaliza la Validación de la petición */


        }



        [HttpPost("InventIncompleto")]
        /// <summary>

        /// Este Método devuelve una lista completa de los Inventarios incompletos registrados en el sistema,
        /// para que el usuario pueda acceder a estos y realizar las modificaciones necesarias para continuar con el inventario.
        /// Para acceder a este método, se debe enviar un post request a: http://localhost:52766/api/Inventario/InventIncompleto
        /// La petición no debe contener ningún parámetro
        /// </summary>
        /// <returns>IActionResult Json con la Lista de Inventarios con Estatus Incompleto</returns>        
        public IActionResult ListInventIncompleto()
        {
            var header = Request.Headers["Authorization"].ToString();
            header = header.ToString().Substring("Bearer ".Length).Trim();
            var ArrHeader = header.Split(".");
            var payload = ArrHeader[1].ToString();

            /*Inicia la Validación de la petición: */
            bool valida;

            valida = new Validaciones().EjecutaValidacion(payload, "Lista Inventario Incompleto");
            if (valida)
            {
                try
                {

                    using (var context = new Oxxo2.DataAccess.OxxoContext())
                    {
                        var InventIncompleto = context.Inventario.FromSql("spGetListaInventarioIncompleto2").ToList();
                        if (InventIncompleto.Count > 0)
                        {
                            return Ok(InventIncompleto);
                        }
                        else
                        {
                            return BadRequest("No se encontraron Inventarios sin Completar");
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


        [HttpPost("modifInvent")]
        /// <summary>
        /// Este Método devuelve los datos del inventario incompleto seleccionado
        /// Además devuelve la lista de Productos del proveedor asociado.
        /// Además devuelve una bandera por cada producto, dónde indica Si este fue seleccionado o no.
        /// para que el usuario pueda acceder a estos y realizar las modificaciones necesarias para continuar con el inventario.
        /// Para acceder a este método, se debe enviar un post request a: http://localhost:52766/api/Inventario/modifInvent
        /// La petición debe contener un Json el id del Inventario.
        /// </summary>
        /// <returns>IActionResult Json con la Lista de Inventarios con Estatus Incompleto</returns>        
        public IActionResult ModificaInventario([FromBody] InventarioJson InventModif)
        {
            /*Declaracion de variables*/
            //int InvId = InventModif.InvId;
            string InvNombre;
            string InvFolio;


            var header = Request.Headers["Authorization"].ToString();
            header = header.ToString().Substring("Bearer ".Length).Trim();
            var ArrHeader = header.Split(".");
            var payload = ArrHeader[1].ToString();

            /*Inicia la Validación de la petición: */
            bool valida;

            valida = new Validaciones().EjecutaValidacion(payload, "Lista Inventario Incompleto");
            if (valida)
            {
                try
                {

                    using (var context = new Oxxo2.DataAccess.OxxoContext())
                    {
                        //Tomo los datos del Inventario del Id que recibo como parámetro:
                        var InventIncompleto = context.Inventario.FromSql("spGetInventarioById @p0", InventModif.InvId).ToList();

                        //Si el inventario existe: 
                        if (InventIncompleto.Count > 0)
                        {
                            InvNombre = InventIncompleto.ElementAt(0).InventarioNombre.ToString();
                            InvFolio = InventIncompleto.ElementAt(0).Folio_Goma.ToString();

                            // Hacer procedimiento que regrese la lista de ProductosInventario por Id de Inventario
                            var ProductosInventario = context.InventarioProducto.FromSql("spGetProdInventIncompleto @p0", InventModif.InvId).ToList();
                           
                            if (ProductosInventario.Count <= 0) //Este if es para los Inventarios que NO tienen producto
                            {
                               

                                InventarioJson Respuesta = new InventarioJson
                                {
                                    InvId = InventModif.InvId,
                                    InventarioNombre = InvNombre,
                                    FolioGoma = InvFolio
                                };

                                return Ok(Respuesta);
                            }
                            else // Este else corresponde a los inventarios que Si tienen productos
                            {
                                int IdProveed = ProductosInventario.ElementAt(0).ProveedorId; // Aquí guardo el ID del proveedor si existe


                                //foreach (var producto in ListaProductos)
                                //{
                                //    SubListaProductosJson SubListaProductosRespuesta = new SubListaProductosJson();
                                //    SubListaProductosRespuesta.selected = false;
                                //    foreach (var selected in ProductosInventario)
                                //    {
                                //        if (producto.ProductoId == selected.ProductoId)
                                //        {
                                //            SubListaProductosRespuesta.selected = true;
                                //        }

                                //    }

                                //    SubListaProductosRespuesta.id = producto.ProductoId;
                                //    SubListaProductosRespuesta.descripcion = producto.productoDescr;
                                //    SubListaProductosRespuesta.proveedorId = producto.ProveedorId;
                                //    SubListaProductosRespuesta.existencia = 0;


                                //    List<SubListaProductosJson> list = new List<SubListaProductosJson>
                                //    {
                                //        SubListaProductosRespuesta
                                //    };
                                //}                              

                                var ListaProductos = context.Producto.FromSql("spGetProdByProveed @p0", IdProveed).ToList();

                                InventarioJson InventarioRespuesta = new InventarioJson
                                {
                                    InvId = InventModif.InvId,
                                    InventarioNombre = InvNombre,
                                    FolioGoma = InvFolio,
                                    ListaDeProductos = new List<SubListaProductosJson>()
                                };

                                foreach (var item in ListaProductos)
                                {
                                    var exists = false;
                                    foreach (var flag in ProductosInventario)
                                    {
                                        if (flag.ProductoId == item.ProductoId)
                                        {
                                            exists = true;
                                        }
                                            
                                    }

                                    SubListaProductosJson sublista = new SubListaProductosJson
                                    {
                                        id = item.ProductoId,
                                        descripcion = item.productoDescr,
                                        proveedorId = IdProveed,
                                        existencia = 0,
                                        selected = exists
                                    };

                                   
                                    InventarioRespuesta.ListaDeProductos.Add((SubListaProductosJson)sublista);
                                }
                               


                                // si el resultado no está vacía, acompleto la lista con los demás productos del proveedor.
                                return Ok(InventarioRespuesta);

                        }
                           
                        }
                        else
                        {
                            return BadRequest("No se encontró el inventario solicitado");
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


        public object ListaProductos()
        {
            return "hola";
        }



    }
}
