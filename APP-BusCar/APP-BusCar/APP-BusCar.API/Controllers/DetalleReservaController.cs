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
    public class DetalleReservaController : ControllerBase
    {
        private readonly IDetalleReservaRepository _DetalleReservaRepository;
        private readonly IMapper _mapper;

        private DetalleReservaController(IDetalleReservaRepository detalleReservaRepository, IMapper mapper)
        {
            _DetalleReservaRepository = detalleReservaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int idReserva)
        {
            var detallesReserva = await _DetalleReservaRepository.GetDetallesReserva(idReserva);

            var detalleReservaList = _mapper.Map<List<DetalleReserva>>(detallesReserva);
            return Ok(detalleReservaList);
        }

        [HttpGet("{idDetalleReserva}")]
        public async Task<IActionResult> GetDetalleReservaById(int idDetalleReserva)
        {
            var detalleReserva = await _DetalleReservaRepository.GetDetalleReserva(idDetalleReserva);
            return Ok(detalleReserva);


        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DetalleReservaCreateDTO detalleReservaDTO)
        {

            var detalleReserva = _mapper.Map<DetalleReserva>(detalleReservaDTO);

            var result = await _DetalleReservaRepository.Insert(detalleReserva);
            return Ok(new { response = result });

        }

        [HttpPut("{idDetalleReserva}")]
        public async Task<IActionResult> Update(int idDetalleReserva, [FromBody] DetalleReservaDTO detalleReservaDTO)
        {
            if (idDetalleReserva != detalleReservaDTO.IdDetalleReserva)
                return BadRequest();

            var detalleReserva = _mapper.Map<DetalleReserva>(detalleReservaDTO);

            var result = await _DetalleReservaRepository.Update(detalleReserva);
            return Ok(new { response = result });
        }

        [HttpDelete("{idDetalleReserva}")]
        public async Task<IActionResult> Delete(int idDetalleReserva)
        {
            var result = await _DetalleReservaRepository.Delete(idDetalleReserva);
            return Ok(new { response = result });

        }
    }
}
