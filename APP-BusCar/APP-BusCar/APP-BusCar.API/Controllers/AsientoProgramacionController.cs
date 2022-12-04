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
    public class AsientoProgramacionController : ControllerBase
    {
        private readonly IAsientoProgramacionRepository _asientoProgramacionRepository;
        private readonly IMapper _mapper;

        public AsientoProgramacionController(IAsientoProgramacionRepository asientoProgramacionRepository, IMapper mapper)
        {
            _asientoProgramacionRepository = asientoProgramacionRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAsientoProgramacionByProgramacion/{idProgramacion}")]
        public async Task<IActionResult> GetAsientoProgramacionByProgramacion(int idProgramacion)
        {
            var asientos = await _asientoProgramacionRepository.GetAsientoProgramacionByProgramacion(idProgramacion);
            var asientoList = _mapper.Map<List<AsientoProgramacionAsientoDTO>>(asientos);
            return Ok(asientoList);
        }

        [HttpGet("GetAsientoProgramacionById/{idAsientoProgramacion}")]
        public async Task<IActionResult> GetAsientoProgramacionById(int idAsientoProgramacion)
        {      

            var asientoProgramacion = await _asientoProgramacionRepository.GetAsientoProgramacionById(idAsientoProgramacion);
            var asientoProgramacionDTO = _mapper.Map<AsientoProgramacionDTO>(asientoProgramacion);
            return Ok(asientoProgramacionDTO);

        }

        [HttpPost("GetOutProgramacionViaje")]
        public async Task<IActionResult> GetOutProgramacionViaje(InProgramacionViaje inProgramacionViaje)
        {
            var output = await _asientoProgramacionRepository.GetOutProgramacionViaje(inProgramacionViaje);
            return Ok(output);
        }

        [HttpPost("GetOutProgramacionAsiento/{idProgramacion}")]
        public async Task<IActionResult> GetOutProgramacionAsiento(int idProgramacion)
        {
            var output = await _asientoProgramacionRepository.GetOutProgramacionAsiento(idProgramacion);            
            return Ok(output);
        }

    }
}
