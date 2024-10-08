using Act_4_2_7.Contracts;
using Act_4_2_7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controllers_Act_4_2_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoService _turnoService;
        public TurnoController(ITurnoService service)
        {
            this._turnoService = service;   
        }
        // GET: api/<TurnoController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<TTurno> turnos = await _turnoService.GetAll();
            if (turnos.Count > 0) 
                return Ok(turnos);
            return Ok("No se encuentran turnos registrados actualmente");
        }

        // GET api/<TurnoController>/5
        [HttpGet("NAME")]
        public async Task<IActionResult> GetByClient([FromQuery]string name)
        {
            List<TTurno> turnos =await _turnoService.GetByClient(name);
            return Ok(turnos);
        }

        // POST api/<TurnoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TTurno turno)
        {
            return Ok(await _turnoService.Save(turno));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            bool result = await _turnoService.Delete(id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]TTurno turno)
        {
            bool result = await _turnoService.Update(turno);
            return Ok(result);
        }
    }
}
