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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioRepository.GetUsuarios();

            var personalList = _mapper.Map<List<UsuarioDTO>>(usuarios);

            return Ok(personalList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var usuario = await _usuarioRepository.GetUsuario(id);
            var usuario2 = _mapper.Map<UsuarioDTO>(usuario);
            return Ok(usuario2);
        }

        [HttpPost("GetOutputDateName")]
        public async Task<IActionResult> GetOutputDateName(Input input)
        {
            var output = await _usuarioRepository.GetOutputDateName(input);            
            return Ok(output);
        }


        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UsuarioCreateDTO usuarioDTO)
        {

            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            var result = await _usuarioRepository.Insert(usuario);
            return Ok(new { Response = result });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            if (id != usuarioDTO.IdUser)
                return BadRequest();

            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            var result = await _usuarioRepository.Update(usuario);
            return Ok(new { Response = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _usuarioRepository.Delete(id);
            return Ok(new { Response = result });
        }

        [HttpGet("GetUsuarioByPersona/{id}")]
        public async Task<IActionResult> GetUsuarioByPersona(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioWithPersonal(id);                
            if (usuario == null)
                return NotFound();

            var usuarioDTO = _mapper.Map<UsuarioPersonalDTO>(usuario);

            return Ok(usuarioDTO);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UsersAuthenticationDTO auth)
        {
            var user = await _usuarioRepository.Login(auth.Usuario1, auth.Clave);
            if (user == null)
                return NotFound();

            var userDTO = _mapper.Map<UsersLoginResponseDTO>(user);

            return Ok(userDTO);
        }

    }
}