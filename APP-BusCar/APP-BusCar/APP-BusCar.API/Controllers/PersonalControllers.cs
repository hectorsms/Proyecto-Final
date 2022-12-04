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
    public class PersonalControllers : ControllerBase
    {
        private readonly IPersonalRepository _IPersonalRepository;
        private readonly IMapper _mapper;

        public PersonalControllers(IPersonalRepository personalRepository, IMapper mapper)
        {
            _IPersonalRepository = personalRepository;
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personal = await _IPersonalRepository.GetPersonal();

            var personalList = _mapper.Map<List<PersonalDTO>>(personal);
            
            return Ok(personalList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonalById(int id)
        {
            var personal = await _IPersonalRepository.GetPersonal(id);
            var personal2 = _mapper.Map<PersonalDTO>(personal);

            return Ok(personal2);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] PersonalCreateDTO personalDTO)
        {
            var personal = _mapper.Map<Personal>(personalDTO);
            var result = await _IPersonalRepository.Insert(personal);
            return Ok(new { Response = result });
        }
    


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonalDTO personalDTO)
        {
            if (id != personalDTO.IdPersonal)
                return BadRequest();

            var personal = _mapper.Map<Personal>(personalDTO);
            var result = await _IPersonalRepository.Update(personal);
            return Ok(new { Response = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _IPersonalRepository.Delete(id);
            return Ok(new { Response = result });
        }

    }
}