﻿using DTOs;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasoDeUso;
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
        public ICUFindAllMantenimiento CUFindAllMantenimiento { get; set; }
        public ICUDeleteMantenimiento CUDeleteMantenimiento { get; set; }
        public ICUAltaMantenimiento CUAltaMantenimiento { get; set; }

        public MantenimientoController(ICUUpdateMantenimiento cUUpdateMantenimiento, ICUFindByIdMantenimiento cUFindByIdMantenimiento, ICUFindAllMantenimiento cUFindAllMantenimiento, ICUDeleteMantenimiento cUDeleteMantenimiento, ICUAltaMantenimiento cUAltaMantenimiento)
        {
            CUUpdateMantenimiento = cUUpdateMantenimiento;
            CUFindByIdMantenimiento = cUFindByIdMantenimiento;
            CUFindAllMantenimiento = cUFindAllMantenimiento;
            CUDeleteMantenimiento = cUDeleteMantenimiento;
            CUAltaMantenimiento = cUAltaMantenimiento;
        }


        // GET: api/<MantenimientoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(CUFindAllMantenimiento.FindAllMantenimiento());
            }
            catch (Exception ex)
            {
                return StatusCode(204);
            }
        }

        // GET api/<MantenimientoController>/5
        [HttpGet("{id}")]
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

        // POST api/<MantenimientoController>
        [HttpPost]
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
                return RedirectToAction("FindById", new { id = dtoMantenimiento.Id });
                //return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<MantenimientoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int MantenimientoId, [FromBody] DTOMantenimiento dtoMantenimiento)
        {
            try
            {
                if (dtoMantenimiento == null)
                {
                    return BadRequest();
                }
                dtoMantenimiento = CUUpdateMantenimiento.UpdateMantenimiento(MantenimientoId, dtoMantenimiento);
                //return CreatedAtRoute("FindById", new { id = dtoMantenimiento.Id}, dtoMantenimiento);
                return RedirectToAction("FindById", new { id = dtoMantenimiento.Id });
                //return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<MantenimientoController>/5
        [HttpDelete("{id}")]
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