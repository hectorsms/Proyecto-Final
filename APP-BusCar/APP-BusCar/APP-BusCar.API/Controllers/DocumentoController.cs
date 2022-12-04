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
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoRepository _documentoRepository;
        private readonly IMapper _mapper;

        public DocumentoController(IDocumentoRepository documentoRepository, IMapper mapper)
        {
            _documentoRepository = documentoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documentos = await _documentoRepository.GetDocumentos();

            var documentoList = _mapper.Map<List<DocumentoDTO>>(documentos);

            return Ok(documentoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentoById(int id)
        {
            var documento = await _documentoRepository.GetDocumento(id);
            return Ok(documento);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DocumentoCreateDTO documentoDTO)
        {
            var documento = _mapper.Map<Documento>(documentoDTO);
            var result = await _documentoRepository.Insert(documento);
            return Ok(new { response = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DocumentoDTO documentoDTO)
        {
            if (id != documentoDTO.IdDocumento)
                return BadRequest();

            var documento = _mapper.Map<Documento>(documentoDTO);

            var result = await _documentoRepository.Update(documento);
            return Ok(new { response = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _documentoRepository.Delete(id);
            return Ok(result);
        }

    }
}