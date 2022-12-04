using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;

namespace APP_BusCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaController(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var marcas = await _marcaRepository.GetMarcas();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarcaById(int id)
        {
            var marca = await _marcaRepository.GetMarca(id);
            return Ok(marca);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Marca marca)
        {
            var result = await _marcaRepository.Insert(marca);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Marca marca)
        {
            if (id != marca.IdMarca)
                return BadRequest();

            var result = await _marcaRepository.Update(marca);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _marcaRepository.Delete(id);
            return Ok(result);
        }
    }
}