using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;

namespace APP_BusCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripulacionController : ControllerBase
    {
        private readonly ITripulacionRepository _tripulacionRepository;

        public TripulacionController(ITripulacionRepository tripulacionRepository)
        {
            _tripulacionRepository = tripulacionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tripulacions = await _tripulacionRepository.GetTripulacions();
            return Ok(tripulacions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripulacionById(int id)
        {
            var tripulacion = await _tripulacionRepository.GetTripulacion(id);
            return Ok(tripulacion);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Tripulacion tripulacion)
        {
            var result = await _tripulacionRepository.Insert(tripulacion);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Tripulacion tripulacion)
        {
            if (id != tripulacion.IdTripulacion)
                return BadRequest();

            var result = await _tripulacionRepository.Update(tripulacion);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tripulacionRepository.Delete(id);
            return Ok(result);
        }
    }
}