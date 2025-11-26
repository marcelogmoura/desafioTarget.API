using desafioTarget.Application.Dtos;
using desafioTarget.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace desafioTarget.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly ProdutoAppService _service;

        public EstoqueController(ProdutoAppService service)
        {
            _service = service;
        }
                
        
        [HttpPost("carga-inicial")]
        public async Task<IActionResult> CargaInicial([FromBody] CargaEstoqueDto cargaDto)
        {
            await _service.CarregarEstoqueInicial(cargaDto);
            return Ok(new { message = "Produtos carregados com sucesso!" });
        }
                
        
        [HttpPost("movimentar")]
        public async Task<IActionResult> Movimentar([FromBody] MovimentacaoDto dto)
        {
            try
            {
                var saldoFinal = await _service.RealizarMovimentacao(dto);
                return Ok(new
                {
                    mensagem = "Movimentação realizada com sucesso",
                    produto = dto.CodigoProduto,
                    estoqueAtual = saldoFinal
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}