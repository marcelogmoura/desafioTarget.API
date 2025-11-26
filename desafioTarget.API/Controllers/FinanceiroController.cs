using desafioTarget.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace desafioTarget.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceiroController : ControllerBase
    {
        private readonly CalculadoraJurosService _service;

        public FinanceiroController(CalculadoraJurosService service)
        {
            _service = service;
        }

        // GET api/financeiro/calculajuros?valor=1000&vencimento=2023-01-01
        // Calcula juros de 2.5% ao dia  
        [HttpGet("calculajuros")]
        public IActionResult CalcularJuros([FromQuery] decimal valor, [FromQuery] DateTime vencimento)
        {
            var valorAtualizado = _service.CalcularValorComJuros(valor, vencimento);
            return Ok(new
            {
                valorOriginal = valor,
                dataVencimento = vencimento.ToString("yyyy-MM-dd"),
                dataCalculo = DateTime.Today.ToString("yyyy-MM-dd"),
                valorFinal = valorAtualizado
            });
        }
    }
}