using DTOs;
using LogicaAplicacion.CasosDeUso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelTipoCabaniasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCabaniaController : ControllerBase
    {

        public ICUUpdateTipoCabania CUUpdateTipoCabania { get; set; }
        public ICUFindByIdTipoCabania CUFindByIdTipoCabania { get; set; }
        public ICUFindByNameTipoCabania CUFindByNameTipoCabania { get; set; }
        public ICUFindAllTipoCabania CUFindAllTipoCabania { get; set; }
        public ICUDeleteTipoCabania CUDeleteTipoCabania { get; set; }
        public ICUAltaTipoCabania CUAltaTipoCabania { get; set; }


        public TipoCabaniaController(ICUUpdateTipoCabania cUUpdateTipoCabania, ICUFindByIdTipoCabania cUFindByIdTipoCabania, ICUFindAllTipoCabania cUFindAllTipoCabania, ICUDeleteTipoCabania cUDeleteTipoCabania, ICUAltaTipoCabania cUAltaTipoCabania, ICUFindByNameTipoCabania cUFindByNameTipoCabania)
        {
            CUUpdateTipoCabania = cUUpdateTipoCabania;
            CUFindByIdTipoCabania = cUFindByIdTipoCabania;
            CUFindAllTipoCabania = cUFindAllTipoCabania;
            CUDeleteTipoCabania = cUDeleteTipoCabania;
            CUAltaTipoCabania = cUAltaTipoCabania;
            CUFindByNameTipoCabania = cUFindByNameTipoCabania;
        }


        // GET: api/<TipoCabaniaController>

        /// <summary>
        /// Devuelve todos los tipos de cabania
        /// </summary>
        /// <response code="200">OK. Devuelve todos los tipos de cabania exitosamente.</response>        
        /// <response code="404">NotFound. No se han encontrado los tipos de cabania.</response>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                return Ok(CUFindAllTipoCabania.FindAllTipoCabania());
            }
            catch (Exception ex)
            {
                return StatusCode(204, ex.Message);
            }
        }

        // GET api/<TipoCabaniaController>/5
        /// <summary>
        /// Devuelve el tipo de cabania que tiene ese Id.
        /// </summary>
        /// <param name="id">Id del tipo de cabania.</param>
        /// <response code="200">OK. Devuelve el tipo de cabania que tiene ese id.</response>        
        /// <response code="404">NotFound. No se ha encontrado el tipo de cabania.</response> 
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                DTOTipoCabania dtoTipoCabania = CUFindByIdTipoCabania.FindByIdTipoCabania(id);
                return Ok(dtoTipoCabania);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        // GET api/<TipoCabaniaController>/Nombre
        /// <summary>
        /// Devuelve el tipo de cabania que tiene ese nombre.
        /// </summary>
        /// <param name="name">Nombre del tipo de cabania.</param>
        /// <response code="200">OK. Devuelve el tipo de cabania que tiene ese nombre.</response>        
        /// <response code="404">NotFound. No se ha encontrado el tipo de cabania.</response> 
        [HttpGet()]
        [Route("Name/{name}")]
        [Authorize]
        public IActionResult GetByName(string name)
        {
            try
            {
                IEnumerable<DTOTipoCabania> listaCabanias = CUFindByNameTipoCabania.FindByNameTipoCabania(name);
                return Ok(listaCabanias);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        // POST api/<TipoCabaniaController>
        /// <summary>
        /// Permite ingresar un Tipo de Cabania.
        /// </summary>

        /// <response code="200">OK. Devuelve el tipo de cabania ingresada.</response>        
        /// <response code="500">Error interno. No se pudo dar de alta el tipo de cabania</response> 
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] DTOTipoCabania dtoTipoCabania)
        {
            try
            {
                if (dtoTipoCabania == null)
                {
                    return BadRequest();
                }
                dtoTipoCabania = CUAltaTipoCabania.AltaTipoCabania(dtoTipoCabania);

                return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<TipoCabaniaController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int TipoCabaniaId, [FromBody] DTOTipoCabania dtoTipoCabania)
        {
            try
            {
                if (dtoTipoCabania == null)
                {
                    return BadRequest();
                }
                dtoTipoCabania = CUUpdateTipoCabania.UpdateTipoCabania(TipoCabaniaId, dtoTipoCabania);
                
                return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<TipoCabaniaController>/5
        /// <summary>
        /// Permite borrar un tipo de cabania
        /// </summary>
        /// <param name="id">Id del tipo de cabania</param>
        /// <response code="200">OK. El tipo de cabania se elimino con exito</response>        
        /// <response code="404">NotFound. No se ha encontrado el tipo de cabania a borrar o este tipo cuenta con cabanias creadas</response> 
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                CUDeleteTipoCabania.DeleteTipoCabania(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
    }
}
