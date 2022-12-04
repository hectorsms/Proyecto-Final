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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteRepository.GetClientes();
            //convert customer to customerDTO

            //var clienteList = new List<ClienteDTO>();
            //foreach (var item in clientes)
            //{
            //    clienteList.Add(new ClienteDTO
            //    {
            //        IdCliente = item.IdCliente,
            //        IdDocumento = item.IdDocumento,
            //        Dni  = item.Dni,
            //        Nombre =item.Nombre,
            //        Apellido  = item.Apellido,
            //        FechaNacimiento = item.FechaNacimiento,
            //        Ruc = item.Ruc ,
            //        RazonSocial =item.RazonSocial,
            //        Sexo =item.Sexo,
            //        Telefono =item.Telefono,
            //        Direccion =item.Direccion,
            //        Estado  = item.Estado
            //    }
            //    );

            //}
            var clienteList = _mapper.Map<List<ClienteDTO>>(clientes);



            return Ok(clienteList);
        }

        [HttpGet("{idCliente}")]
        public async Task<IActionResult> GetClienteById(int idCliente)
        {
            var customer = await _clienteRepository.GetCliente(idCliente);
            return Ok(customer);


        }
        [HttpGet("GetClienteByDocumento")]
        public async Task<IActionResult> GetClienteByDocumento([FromQuery] int idDocumento, String dni)
        {
            var cliente = await _clienteRepository.GetClienteDoc(idDocumento, dni);
            return Ok(cliente);

        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ClienteCreateDTO clienteDTO)
        {

            var cliente = _mapper.Map<Cliente>(clienteDTO);

            var result = await _clienteRepository.Insert(cliente);
            return Ok(new { response = result });

        }

        [HttpPut("{idCliente}")]
        public async Task<IActionResult> Update(int idCliente, [FromBody] ClienteDTO clienteDTO)
        {
            if (idCliente != clienteDTO.IdCliente)
                return BadRequest();

            var cliente = _mapper.Map<Cliente>(clienteDTO);

            var result = await _clienteRepository.Update(cliente);
            return Ok(new { response = result });

        }

        [HttpDelete("{idCliente}")]
        public async Task<IActionResult> Delete(int idCliente)
        {
            var result = await _clienteRepository.Delete(idCliente);
            return Ok(new { response = result });

        }

    }
}