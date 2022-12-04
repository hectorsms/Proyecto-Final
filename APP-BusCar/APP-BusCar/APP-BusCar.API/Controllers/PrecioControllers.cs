using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;

namespace APP_BusCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecioControllers : ControllerBase
    {
        private readonly IPrecioRepository _IPrecioRepository;

        public PrecioControllers(IPrecioRepository precioRepository)
        {
            _IPrecioRepository = precioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Precio = await _IPrecioRepository.GetPrecio();
            return Ok(Precio);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrecioById(int id)
        {
            var Precio = await _IPrecioRepository.GetPrecio(id);
            return Ok(Precio);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Precio Precio)
        {
            var result = await _IPrecioRepository.Insert(Precio);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Precio Precio)
        {
            if (id != Precio.IdPrecio)
                return BadRequest();

            var result = await _IPrecioRepository.Update(Precio);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _IPrecioRepository.Delete(id);
            return Ok(result);
        }

    }
}