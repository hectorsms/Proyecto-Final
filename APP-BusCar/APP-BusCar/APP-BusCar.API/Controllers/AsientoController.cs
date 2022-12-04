using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_APP_BusCar.DOMAIN.Core.DTOs;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;


namespace APP_BusCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoController : ControllerBase
    {
        private readonly IAsientoRepository _asientoRepository;
        private readonly IMapper _mapper;
        public AsientoController(IAsientoRepository asientoRepository, IMapper mapper)
        {
            _asientoRepository = asientoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var asientos = await _asientoRepository.GetAsientos();
            var asientoList = _mapper.Map<List<AsientoDTO>>(asientos);
            return Ok(asientoList);
        }
        [HttpGet("{idAsiento}")]
        public async Task<IActionResult> GetAsientoById(int idAsiento)
        {
            var asiento = await _asientoRepository.GetAsiento(idAsiento);
            return Ok(asiento);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] AsientoCreateDTO asientoDTO)
        {

            var asiento = _mapper.Map<Asiento>(asientoDTO);

            var result = await _asientoRepository.Insert(asiento);
            return Ok(new { response = result });

        }

        [HttpPut("{idAsiento}")]
        public async Task<IActionResult> Update(int idAsiento, [FromBody] AsientoDTO asientoDTO)
        {
            if (idAsiento != asientoDTO.IdAsiento)
                return BadRequest();

            var asiento = _mapper.Map<Asiento>(asientoDTO);

            var result = await _asientoRepository.Update(asiento);
            return Ok(new { response = result });

        }

        [HttpDelete("{idAsiento}")]
        public async Task<IActionResult> Delete(int idAsiento)
        {
            var result = await _asientoRepository.Delete(idAsiento);
            return Ok(new { response = result });

        }

    }
}
