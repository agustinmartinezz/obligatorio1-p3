using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasoDeUso;
using Microsoft.AspNetCore.Mvc;
using DTOs;
using LogicaNegocio.EntidadesNegocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelCabaniasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabaniaController : ControllerBase
    {  
        public ICUUpdateCabania CUUpdateCabania {get; set;}
        public ICUFindHabilitadasCabania CUFindHabilitadasCabania {get; set;}
        public ICUFindByTipoCabania CUFindByTipoCabania {get; set;}
        public ICUFindByNameCabania CUFindByNameCabania {get; set;}
        public ICUFindByMaxPeopleCabania CUFindByMaxPeopleCabania {get; set;}
        public ICUFindByIdCabania CUFindByIdCabania {get; set;}
        public ICUFindAllCabania CUFindAllCabania {get; set;}
        public ICUDeleteCabania CUDeleteCabania {get; set;}
        public ICUAltaCabania CUAltaCabania {get; set;}



        public CabaniaController(ICUUpdateCabania cUUpdateCabania, ICUFindHabilitadasCabania cUFindHabilitadasCabania, ICUFindByTipoCabania cUFindByTipoCabania, ICUFindByNameCabania cUFindByNameCabania, ICUFindByMaxPeopleCabania cUFindByMaxPeopleCabania, ICUFindByIdCabania cUFindByIdCabania, ICUFindAllCabania cUFindAllCabania, ICUDeleteCabania cUDeleteCabania, ICUAltaCabania cUAltaCabania)
        {
            CUUpdateCabania = cUUpdateCabania;
            CUFindHabilitadasCabania = cUFindHabilitadasCabania;
            CUFindByTipoCabania = cUFindByTipoCabania;
            CUFindByNameCabania = cUFindByNameCabania;
            CUFindByMaxPeopleCabania = cUFindByMaxPeopleCabania;
            CUFindByIdCabania = cUFindByIdCabania;
            CUFindAllCabania = cUFindAllCabania;
            CUDeleteCabania = cUDeleteCabania;
            CUAltaCabania = cUAltaCabania;
        }


        // GET: api/<CabaniaController>
        /// <summary>
        /// Obtiene todas las cabanias.
        /// </summary>
        /// <response code="200">OK. Devuelve todas las cabanias.</response>        
        /// <response code="404">NotFound. No se han encontrado las cabanias.</response>        

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(CUFindAllCabania.FindAllCabania());
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        // GET: api/<CabaniaController>/Habilitadas

        /// <summary>
        /// Obtiene las cabanias que estan habilitadas.
        /// </summary>
        /// <response code="200">OK. Devuelve todas las cabanias que estan habilitadas.</response>        
        /// <response code="404">NotFound. No se han encontrado las cabanias.</response>  
        [HttpGet]
        [Route("Habilitadas")]
        public IActionResult GetHabilitadas()
        {
            try
            {
                return Ok(CUFindHabilitadasCabania.FindHabilitadasCabania());
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        // GET api/<CabaniaController>/5

        /// <summary>
        /// Devuelve la cabania que tiene ese id..
        /// </summary>
        /// <param name="id">Id de la cabania.</param>
        /// <response code="200">OK. Devuelve la cabania que tiene ese id.</response>        
        /// <response code="404">NotFound. No se ha encontrado la cabania.</response> 
        [HttpGet()]
        [Route("Id/{id}")]

        public IActionResult GetById(int id)
        {
            try
            {
                DTOCabania dtoCabania = CUFindByIdCabania.FindByIdCabania(id);
                return Ok(dtoCabania);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        // GET api/<CabaniaController>/Nombre/"Nombre"
        /// <summary>
        /// Devuelve la cabania que tiene ese nombre.
        /// </summary>
        /// <param name="name">Nombre de la cabania.</param>
        /// <response code="200">OK. Devuelve la cabania que tiene ese nombre.</response>        
        /// <response code="404">NotFound. No se ha encontrado la cabania.</response> 
        [HttpGet()]
        [Route("Name/{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                IEnumerable<DTOCabania> listaCabanias = CUFindByNameCabania.FindByNameCabania(name);
                return Ok(listaCabanias);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        // GET api/<CabaniaController>/Tipo/5
        /// <summary>
        /// Obtiene las cabanias de un tipo en especifico.
        /// </summary>
        /// <param name="tipoId">Id del tipo de la cabania.</param>
        /// <response code="200">OK. Devuelve las cabanias de ese tipo.</response>        
        /// <response code="404">NotFound. No se han encontrado la scabanias.</response> 
        [HttpGet()]
        [Route("Type/{tipoId}")]
        public IActionResult GetByTipo(int tipoId)
        {
            try
            {
                IEnumerable<DTOCabania> listaCabanias = CUFindByTipoCabania.FindByTipoCabania(tipoId);
                return Ok(listaCabanias);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        // GET api/<CabaniaController>/MaxPeople/5
        /// <summary>
        /// Obtiene las cabanias que permiten alojar a esta cantidad de personas.
        /// </summary>
        /// <param name="maxPeople">Cantidad de personas a alojar</param>
        /// <response code="200">OK. Devuelve las cabanias que permiten esa o una mayor cantidad de personas.</response>        
        /// <response code="404">NotFound. No se han encontrado las cabanias.</response> 
        [HttpGet()]
        [Route("Cupos/{maxPeople}")]

        public IActionResult GetByMaxPeople(int maxPeople)
        {
            try
            {
                IEnumerable<DTOCabania> listaCabanias = CUFindByMaxPeopleCabania.FindByMaxPeopleCabania(maxPeople);
                return Ok(listaCabanias);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

       
        // POST api/<CabaniaController>
        /// <summary>
        /// Permite ingresar una Cabania.
        /// </summary>
      
        /// <response code="200">OK. Devuelve la cabania ingresada.</response>        
        /// <response code="500">Error interno. No se pudo dar de alta la Cabania</response> 
        [HttpPost]
        public IActionResult Post([FromBody] DTOCabania dtoCabania)
        {
            try
            {
                if (dtoCabania == null)
                {
                    return BadRequest();
                }
                dtoCabania = CUAltaCabania.AltaCabania(dtoCabania);
                //return CreatedAtRoute("FindById", new { id = dtoCabania.Id}, dtoCabania);
                //return RedirectToAction("Id", new { id = dtoCabania.Id });
                return Ok(dtoCabania);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<CabaniaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int CabaniaId, [FromBody] DTOCabania dtoCabania)
        {
            try
            {
                if (dtoCabania == null)
                {
                    return BadRequest();
                }
                dtoCabania = CUUpdateCabania.UpdateCabania(CabaniaId, dtoCabania);
                //return CreatedAtRoute("FindById", new { id = dtoCabania.Id}, dtoCabania);
                return RedirectToAction("FindById", new { id = dtoCabania.Id });
                //return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<CabaniaController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                CUDeleteCabania.DeleteCabania(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
    }
}
