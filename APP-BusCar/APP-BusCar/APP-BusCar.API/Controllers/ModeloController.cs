using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;

namespace APP_BusCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloController(IModeloRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var modelos = await _modeloRepository.GetModelos();
            return Ok(modelos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModeloById(int id)
        {
            var modelo = await _modeloRepository.GetModelo(id);
            return Ok(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Modelo modelo)
        {
            var result = await _modeloRepository.Insert(modelo);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Modelo modelo)
        {
            if (id != modelo.IdModelo)
                return BadRequest();

            var result = await _modeloRepository.Update(modelo);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _modeloRepository.Delete(id);
            return Ok(result);
        }

    }
}