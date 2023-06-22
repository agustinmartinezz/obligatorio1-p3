using DTOs;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasoDeUso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelMantenimientosWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        public ICUUpdateMantenimiento CUUpdateMantenimiento { get; set; }
        public ICUFindByIdMantenimiento CUFindByIdMantenimiento { get; set; }
        public ICUFindByDateMantenimiento CUFindByDateMantenimiento { get; set; }
        public ICUFindAllMantenimiento CUFindAllMantenimiento { get; set; }
        public ICUDeleteMantenimiento CUDeleteMantenimiento { get; set; }
        public ICUAltaMantenimiento CUAltaMantenimiento { get; set; }

        public MantenimientoController(ICUUpdateMantenimiento cUUpdateMantenimiento, ICUFindByIdMantenimiento cUFindByIdMantenimiento, ICUFindByDateMantenimiento cUFindByDateMantenimiento, ICUFindAllMantenimiento cUFindAllMantenimiento, ICUDeleteMantenimiento cUDeleteMantenimiento, ICUAltaMantenimiento cUAltaMantenimiento)
        {
            CUUpdateMantenimiento = cUUpdateMantenimiento;
            CUFindByIdMantenimiento = cUFindByIdMantenimiento;
            CUFindByDateMantenimiento = cUFindByDateMantenimiento;
            CUFindAllMantenimiento = cUFindAllMantenimiento;
            CUDeleteMantenimiento = cUDeleteMantenimiento;
            CUAltaMantenimiento = cUAltaMantenimiento;
        }


        // GET: api/<MantenimientoController>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        return Ok(CUFindAllMantenimiento.FindAllMantenimiento());
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(204, ex.Message);
        //    }
        //}

        // GET api/<MantenimientoController>/5

        /// <summary>
        /// Devuelve el mantenimiento que tiene ese id.
        /// </summary>
        /// <param name="id">Id de el mantenimiento.</param>
        /// <response code="200">OK. Devuelve el mantenimiento que tiene ese id.</response>        
        /// <response code="404">NotFound. No se ha encontrado el mantenimiento.</response> 
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                DTOMantenimiento dtoMantenimiento = CUFindByIdMantenimiento.FindByIdMantenimiento(id);
                return Ok(dtoMantenimiento);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        /// <summary>
        /// Devuelve los mantenimientos que estan en ese rango de fechas.
        /// </summary>
        /// <param name="cabaniaId">Id de la cabania asociada al mantenimiento.</param>
        /// <param name="fechaDesde">Fecha desde para mostrar mantenimientos.</param>
        /// <param name="fechaHasta">Fecha hasta para mostrar mantenimientos.</param>
        /// <response code="200">OK. Devuelve la cabania que tiene ese id.</response>        
        /// <response code="404">NotFound. No se ha encontrado la cabania.</response> 
        [HttpGet()]
        [Route("Dates/cabaniaId={cabaniaId}&fechaDesde={fechaDesde}&fechaHasta={fechaHasta}")]
        [Authorize]
        public IActionResult Get(int cabaniaId, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                IEnumerable<DTOMantenimiento> dtoMantenimientos = CUFindByDateMantenimiento.FindByDates(cabaniaId, fechaDesde, fechaHasta);
                return Ok(dtoMantenimientos);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }


        /// <summary>
        /// Permite ingresar un mantenimiento
        /// </summary>
        /// <response code="200">OK. Devuelve el mantenimientoq ue se dio de alta</response>        
        /// <response code="500">Error interno. No se pudo dar de alta el mantenimiento</response> 

        // POST api/<MantenimientoController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] DTOMantenimiento dtoMantenimiento)
        {
            try
            {
                if (dtoMantenimiento == null)
                {
                    return BadRequest();
                }
                dtoMantenimiento = CUAltaMantenimiento.AltaMantenimiento(dtoMantenimiento);
                //return CreatedAtRoute("FindById", new { id = dtoMantenimiento.Id}, dtoMantenimiento);
                //return RedirectToAction("FindById", new { id = dtoMantenimiento.Id });
                return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<MantenimientoController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int MantenimientoId, [FromBody] DTOMantenimiento dtoMantenimiento)
        //{
        //    try
        //    {
        //        if (dtoMantenimiento == null)
        //        {
        //            return BadRequest();
        //        }
        //        dtoMantenimiento = CUUpdateMantenimiento.UpdateMantenimiento(MantenimientoId, dtoMantenimiento);
        //        //return CreatedAtRoute("FindById", new { id = dtoMantenimiento.Id}, dtoMantenimiento);
        //        return RedirectToAction("FindById", new { id = dtoMantenimiento.Id });
        //        //return Ok();
        //    }

        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}




        // DELETE api/<MantenimientoController>/5
        /// <summary>
        /// Permite borrar un mantenimiento
        /// </summary>
        /// <param name="id">Id del mantenimiento</param>
        /// <response code="200">OK. El mantenimiento se elimino con exito</response>        
        /// <response code="404">NotFound. No se ha encontrado el mantenimiento a borrar.</response> 
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                CUDeleteMantenimiento.DeleteMantenimiento(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
    }
}
