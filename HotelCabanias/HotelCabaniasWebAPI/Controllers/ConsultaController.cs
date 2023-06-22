using DTOs;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasoDeUso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Runtime.Intrinsics.X86;

namespace HotelCabaniasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        public ICUConsultaA CUConsultaA { get; set; }
        public ICUConsultaB CUConsultaB { get; set; }

        public ConsultaController(ICUConsultaA cUConsultaA, ICUConsultaB cUConsultaB)
        {
            CUConsultaA = cUConsultaA;
            CUConsultaB = cUConsultaB;
        }


        // POST api/<CabaniaController>
        /// <summary>
        ///Dados el identificador de un tipo y un monto obtener el nombre y capacidad (cantidad de huéspedes que puede alojar) de las cabañas de ese tipo que tengan un costo diario menor a ese monto, que tengan jacuzzi y estén habilitadas para reserva.
        /// </summary>

        /// <response code="200">OK. Devuelve los resultados esperados.</response>     
        /// <response code="204">No Content. Si la consulta no tiene resultados.</response>        
        /// <response code="500">Error interno. No se pudo ejecutar la consulta correctamente</response> 
        [Route("A")]
        [HttpPost]
        public IActionResult ConsultaA(int tipoId, int monto)
        {
            try
            {
                IEnumerable<object> lista = CUConsultaA.ConsultaA(tipoId, monto);

                if (lista.Any())
                {
                    return Ok(lista);
                } else
                {
                    return NoContent();
                }
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        ///Dados el identificador de un tipo y un monto obtener el nombre y capacidad (cantidad de huéspedes que puede alojar) de las cabañas de ese tipo que tengan un costo diario menor a ese monto, que tengan jacuzzi y estén habilitadas para reserva.
        /// Dados dos valores, obtener los mantenimientos realizados a las cabañas con una capacidad que esté comprendida(topes inclusive) entre ambos valores.El resultado se agrupará por nombre de la persona que realizó el mantenimiento, e incluirá el nombre de la persona y el monto total de mantenimientos que realizó.
        /// </summary>

        /// <response code="200">OK. Devuelve los resultados esperados.</response>     
        /// <response code="204">No Content. Si la consulta no tiene resultados.</response>        
        /// <response code="500">Error interno. No se pudo ejecutar la consulta correctamente</response> 

        [Route("B")]
        [HttpPost]
        public IActionResult ConsultaB(int desde, int hasta)
        {
            try
            {
                IEnumerable<object> lista = CUConsultaB.ConsultaB(desde, hasta);

                if (lista.Any())
                {
                    return Ok(lista);
                }
                else
                {
                    return NoContent();
                }
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
