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
    public class ComprobanteController : ControllerBase
    {


        private readonly IComprobanteRepository _comprobanteRepository;
        private readonly IMapper _mapper;

        public ComprobanteController(IComprobanteRepository comprobanteRepository, IMapper mapper)
        {
            _comprobanteRepository = comprobanteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comprobantes = await _comprobanteRepository.GetComprobantes();

            var comprobanteList = _mapper.Map<List<ComprobanteDTO>>(comprobantes);
            return Ok(comprobanteList);
        }

        [HttpGet("{idComprobante}")]
        public async Task<IActionResult> GetClienteById(int idComprobante)
        {
            var comprobante = await _comprobanteRepository.GetComprobante(idComprobante);
            return Ok(comprobante);


        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ComprobanteCreateDTO comprobanteDTO)
        {

            var comprobante = _mapper.Map<Comprobante>(comprobanteDTO);

            var result = await _comprobanteRepository.Insert(comprobante);
            return Ok(new { response = result });

        }

        [HttpPut("{idComprobante}")]
        public async Task<IActionResult> Update(int idComprobante, [FromBody] ComprobanteDTO comprobanteDTO)
        {
            if (idComprobante != comprobanteDTO.IdComprobante)
                return BadRequest();

            var comprobante = _mapper.Map<Comprobante>(comprobanteDTO);

            var result = await _comprobanteRepository.Update(comprobante);
            return Ok(new { response = result });
        }

        [HttpDelete("{idComprobante}")]
        public async Task<IActionResult> Delete(int idComprobante)
        {
            var result = await _comprobanteRepository.Delete(idComprobante);
            return Ok(new { response = result });

        }




    }
}