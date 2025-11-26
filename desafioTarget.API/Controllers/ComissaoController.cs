using desafioTarget.Application.Dtos;
using desafioTarget.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace desafioTarget.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComissaoController : ControllerBase
    {
        private readonly VendaAppService _service;

        public ComissaoController(VendaAppService service)
        {
            _service = service;
        }
                
        
        [HttpPost("calcular")]
        public IActionResult CalcularComissao([FromBody] ListaVendasDto vendasDto)
        {
            var resultado = _service.ProcessarVendas(vendasDto);
            return Ok(resultado);
        }
    }
}