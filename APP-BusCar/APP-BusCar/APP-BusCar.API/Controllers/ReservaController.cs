using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;

namespace APP_BusCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservas = await _reservaRepository.GetReservas();
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservaById(int id)
        {
            var reserva = await _reservaRepository.GetReserva(id);
            return Ok(reserva);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Reserva reserva)
        {
            var result = await _reservaRepository.Insert(reserva);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Reserva reserva)
        {
            if (id != reserva.IdReserva)
                return BadRequest();

            var result = await _reservaRepository.Update(reserva);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _reservaRepository.Delete(id);
            return Ok(result);
        }
    }
}

