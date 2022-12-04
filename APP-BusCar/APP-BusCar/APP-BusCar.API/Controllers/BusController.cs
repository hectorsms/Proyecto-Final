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
    public class BusController : ControllerBase
    {
        private readonly IBusRepository _busRepository;
        private readonly IMapper _mapper;

        public BusController (IBusRepository busRepository, IMapper mapper)
        {
            _busRepository = busRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bus = await _busRepository.GetBuses();
           
            var clienteList = _mapper.Map<List<BusDTO>>(bus);



            return Ok(clienteList);
        }

        [HttpGet("{IdBus}")]
        public async Task<IActionResult> GetBusById(int IdBus)
        {
            var bus = await _busRepository.GetBus(IdBus);
            return Ok(bus);


        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] BusCreateDTO BusDTO)
        {

            var bus = _mapper.Map<Bus>(BusDTO);

            var result = await _busRepository.Insert(bus);
            return Ok(new { response = result });

        }

        [HttpPut("{IdBus}")]
        public async Task<IActionResult> Update(int idbus, [FromBody] BusDTO BusDTO)
        {
            if (idbus != BusDTO.IdBus)
                return BadRequest();

            var bus = _mapper.Map<Bus>(BusDTO);

            var result = await _busRepository.Update(bus);
            return Ok(new { response = result });

        }

        [HttpDelete("{IdBus}")]
        public async Task<IActionResult> Delete(int IdBus)
        {
            var result = await _busRepository.Delete(IdBus);
            return Ok(new { response = result });

        }

    }
}