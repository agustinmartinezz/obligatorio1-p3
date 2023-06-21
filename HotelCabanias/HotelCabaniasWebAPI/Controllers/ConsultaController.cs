using DTOs;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasoDeUso;
using Microsoft.AspNetCore.Mvc;

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
