using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;

namespace APP_BusCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Pagos_PaypalControllers : ControllerBase
    {
        private readonly IPagos_PaypalRepository _Pagos_PaypalRepository;

        public Pagos_PaypalControllers(IPagos_PaypalRepository Pagos_PaypalRepository)
        {
            _Pagos_PaypalRepository = Pagos_PaypalRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Precio = await _Pagos_PaypalRepository.GetPagosPaypal();
            return Ok(Precio);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPagosPaypalById(int id)
        {
            var PagosPaypal = await _Pagos_PaypalRepository.GetPagosPaypal(id);
            return Ok(PagosPaypal);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] PagosPaypal PagosPaypal)
        {
            var result = await _Pagos_PaypalRepository.Insert(PagosPaypal);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PagosPaypal PagosPaypal)
        {
            if (id != PagosPaypal.IdPago)
                return BadRequest();

            var result = await _Pagos_PaypalRepository.Update(PagosPaypal);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _Pagos_PaypalRepository.Delete(id);
            return Ok(result);
        }
    }
}