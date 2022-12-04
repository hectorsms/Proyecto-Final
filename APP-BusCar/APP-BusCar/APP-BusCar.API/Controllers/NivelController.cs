using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;

namespace APP_BusCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NivelController : ControllerBase
    {
        private readonly INivelRepository _nivelRepository;

        public NivelController(INivelRepository nivelRepository)
        {
            _nivelRepository = nivelRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var niveles = await _nivelRepository.GetNiveles();
            return Ok(niveles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNivelById(int id)
        {
            var nivel = await _nivelRepository.GetNivel(id);
            return Ok(nivel);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Nivel nivel)
        {
            var result = await _nivelRepository.Insert(nivel);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Nivel nivel)
        {
            if (id != nivel.IdNivel)
                return BadRequest();

            var result = await _nivelRepository.Update(nivel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _nivelRepository.Delete(id);
            return Ok(result);
        }


    }
}