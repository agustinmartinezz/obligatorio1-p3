using DTOs;
using LogicaAplicacion.CasosDeUso;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelUsuariosWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        public ICUUpdateUsuario CUUpdateUsuario { get; set; }
        public ICUFindByIdUsuario CUFindByIdUsuario { get; set; }
        public ICULoguearUsuario CULoguearUsuario { get; set; }
        public ICUFindAllUsuario CUFindAllUsuario { get; set; }
        public ICUDeleteUsuario CUDeleteUsuario { get; set; }
        public ICUAltaUsuario CUAltaUsuario { get; set; }


        public UsuarioController(ICUUpdateUsuario cUUpdateUsuario, ICUFindByIdUsuario cUFindByIdUsuario, ICUFindAllUsuario cUFindAllUsuario, ICUDeleteUsuario cUDeleteUsuario, ICUAltaUsuario cUAltaUsuario, ICULoguearUsuario cULoguearUsuario)
        {
            CUUpdateUsuario = cUUpdateUsuario;
            CUFindByIdUsuario = cUFindByIdUsuario;
            CUFindAllUsuario = cUFindAllUsuario;
            CUDeleteUsuario = cUDeleteUsuario;
            CUAltaUsuario = cUAltaUsuario;
            CULoguearUsuario = cULoguearUsuario;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(CUFindAllUsuario.FindAllUsuario());
            }
            catch (Exception ex)
            {
                return StatusCode(204);
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                DTOUsuario dtoUsuario = CUFindByIdUsuario.FindByIdUsuario(id);
                return Ok(dtoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post([FromBody] DTOUsuario dtoUsuario)
        {
            try
            {
                if (dtoUsuario == null)
                {
                    return BadRequest();
                }
                dtoUsuario = CUAltaUsuario.AltaUsuario(dtoUsuario);
                //return CreatedAtRoute("FindById", new { id = dtoUsuario.Id}, dtoUsuario);
                return RedirectToAction("FindById", new { id = dtoUsuario.Id });
                //return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int UsuarioId, [FromBody] DTOUsuario dtoUsuario)
        {
            try
            {
                if (dtoUsuario == null)
                {
                    return BadRequest();
                }
                dtoUsuario = CUUpdateUsuario.UpdateUsuario(UsuarioId, dtoUsuario);
                //return CreatedAtRoute("FindById", new { id = dtoUsuario.Id}, dtoUsuario);
                return RedirectToAction("FindById", new { id = dtoUsuario.Id });
                //return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                CUDeleteUsuario.DeleteUsuario(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
    }
}
