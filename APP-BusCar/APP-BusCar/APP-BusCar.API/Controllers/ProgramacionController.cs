using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;

namespace APP_BusCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramacionController : ControllerBase
    {
        private readonly IProgramacionRepository _programacionRepository;

        public ProgramacionController(IProgramacionRepository programacionRepository)
        {
            _programacionRepository = programacionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var programacions = await _programacionRepository.GetProgramacions();
            return Ok(programacions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramacionById(int id)
        {
            var programacion = await _programacionRepository.GetProgramacion(id);
            return Ok(programacion);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Programacion programacion)
        {
            var result = await _programacionRepository.Insert(programacion);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Programacion programacion)
        {
            if (id != programacion.IdProgramacion)
                return BadRequest();

            var result = await _programacionRepository.Update(programacion);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _programacionRepository.Delete(id);
            return Ok(result);
        }
    }
}