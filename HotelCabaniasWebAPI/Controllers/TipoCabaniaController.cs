using DTOs;
using LogicaAplicacion.CasosDeUso;
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
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(CUFindAllTipoCabania.FindAllTipoCabania());
            }
            catch (Exception ex)
            {
                return StatusCode(204);
            }
        }

        // GET api/<TipoCabaniaController>/5
        [HttpGet("{id}")]
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
        [HttpGet()]
        [Route("Name/{name}")]

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
        [HttpPost]
        public IActionResult Post([FromBody] DTOTipoCabania dtoTipoCabania)
        {
            try
            {
                if (dtoTipoCabania == null)
                {
                    return BadRequest();
                }
                dtoTipoCabania = CUAltaTipoCabania.AltaTipoCabania(dtoTipoCabania);
                //return CreatedAtRoute("FindById", new { id = dtoTipoCabania.Id}, dtoTipoCabania);
                return RedirectToAction("FindById", new { id = dtoTipoCabania.Id });
                //return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<TipoCabaniaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int TipoCabaniaId, [FromBody] DTOTipoCabania dtoTipoCabania)
        {
            try
            {
                if (dtoTipoCabania == null)
                {
                    return BadRequest();
                }
                dtoTipoCabania = CUUpdateTipoCabania.UpdateTipoCabania(TipoCabaniaId, dtoTipoCabania);
                //return CreatedAtRoute("FindById", new { id = dtoTipoCabania.Id}, dtoTipoCabania);
                return RedirectToAction("FindById", new { id = dtoTipoCabania.Id });
                //return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<TipoCabaniaController>/5
        [HttpDelete("{id}")]
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
