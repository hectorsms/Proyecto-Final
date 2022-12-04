using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_APP_BusCar.DOMAIN.Core.DTOs;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;
using PROYECTO_APP_BusCar.DOMAIN.infrastructure.Repositories;

namespace APP_BusCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrigenController : ControllerBase
    {
        private readonly IOrigenRepository _OrigenRepository;
        private readonly IMapper _mapper;
        public OrigenController(IOrigenRepository origenRepository, IMapper mapper)
        {
            _OrigenRepository = origenRepository;
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var origen = await _OrigenRepository.GetOrigen();
            var origenList = _mapper.Map<List<OrigenDTO>>(origen);
            return Ok(origenList);
        }

        [HttpGet("{idOrigen}")]
        public async Task<IActionResult> GetOrigenById(int idOrigen)
        {
            var origen = await _OrigenRepository.GetOrigen(idOrigen);
            var origen2 = _mapper.Map<OrigenDTO>(origen);
            return Ok(origen2);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] OrigenCreateDTO origenDTO)
        {
            var origen = _mapper.Map<Origen>(origenDTO);

            var result = await _OrigenRepository.Insert(origen);
            return Ok(new { response = result });
        }

        [HttpPut("{idOrigen}")]
        public async Task<IActionResult> Update(int idOrigen, [FromBody] OrigenDTO origenDTO)
        {
            if (idOrigen != origenDTO.IdOrigen)
                return BadRequest();

            var origen = _mapper.Map<Origen>(origenDTO);

            var result = await _OrigenRepository.Update(origen);
            return Ok(new { response = result });
        }

        [HttpDelete("{idOrigen}")]
        public async Task<IActionResult> Delete(int idOrigen)
        {
            var result = await _OrigenRepository.Delete(idOrigen);
            return Ok(new { response = result });
        }

    }
}