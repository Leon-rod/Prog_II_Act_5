using Act_4_2_7.Contracts;
using Act_4_2_7.Implementations;
using Act_4_2_7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controllers_Act_4_2_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService service)
        {
            this._serviceService = service;
        }
        // GET: api/<ServiceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serviceService.GetByName(""));
        }

        // GET api/<ServiceController>/5
        [HttpGet("Servicio")]
        public async Task<IActionResult>  Get([FromQuery]string name)
        {
            return Ok(await _serviceService.GetByName(name));
        }

        // POST api/<ServiceController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TServicio service)
        {
            if (await _serviceService.Save(service))
                return Ok($"Se ha agregado con éxito el servicio: {service.Nombre}");
            return BadRequest($"No se pudo agregar el servicio {service.Nombre}");
        }

        // PUT api/<ServiceController>/5
        [HttpPut("Id")]
        public async Task<IActionResult> Put([FromBody] TServicio service, [FromQuery]int id)
        {
            if (await _serviceService.Update(service, id))
                return Ok($"Se ha actualizado con exito el servicio: {service.Nombre}");
            return BadRequest("Ha ocurrido un error al intentar actualizar un sevicio, intente más tarde...");
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await _serviceService.Delete(id) ? Ok("Se ha eliminado un servicio de la base de datos con exito!") : BadRequest("Ha ocurrido un error al intentar eliminar un servicio de la base de datos...");
        }
    }
}
