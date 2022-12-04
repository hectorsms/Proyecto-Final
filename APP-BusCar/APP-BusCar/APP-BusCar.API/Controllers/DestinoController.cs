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
    public class DestinoController : ControllerBase
    {
        private readonly IDestinoRepository _destinoRepository;
        private readonly IMapper _mapper;

        public DestinoController(IDestinoRepository destinoRepository, IMapper mapper)
        {
            _destinoRepository = destinoRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var destinos = await _destinoRepository.GetDestinos();

            var destinoList = _mapper.Map<List<DestinoDTO>>(destinos);
            return Ok(destinoList);
        }

        [HttpGet("{idDestino}")]
        public async Task<IActionResult> GetDestinoById(int idDestino)
        {
            var destino = await _destinoRepository.GetDestino(idDestino);
            var destino2 = _mapper.Map<DestinoDTO>(destino);
            return Ok(destino2);
        }


        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DestinoCreateDTO destinoDTO)
        {

            var destino = _mapper.Map<Destino>(destinoDTO);

            var result = await _destinoRepository.Insert(destino);
            return Ok(new { response = result });

        }

        [HttpPut("{idDestino}")]
        public async Task<IActionResult> Update(int idDestino, [FromBody] DestinoDTO destinoDTO)
        {
            if (idDestino != destinoDTO.IdDestino)
                return BadRequest();

            var destino = _mapper.Map<Destino>(destinoDTO);

            var result = await _destinoRepository.Update(destino);
            return Ok(new { response = result });
        }

        [HttpDelete("{idDestino}")]
        public async Task<IActionResult> Delete(int idDestino)
        {
            var result = await _destinoRepository.Delete(idDestino);
            return Ok(new { response = result });

        }


    }
}