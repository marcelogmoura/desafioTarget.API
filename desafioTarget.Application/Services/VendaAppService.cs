using desafioTarget.Application.Dtos;
using desafioTarget.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace desafioTarget.Application.Services
{
    
    public class VendaAppService
    {
        private readonly CalculadoraComissaoService _calculadoraService;

        // Injeção de dependência do serviço de domínio
        public VendaAppService(CalculadoraComissaoService calculadoraService)
        {
            _calculadoraService = calculadoraService;
        }

        public List<RelatorioComissaoDto> ProcessarVendas(ListaVendasDto entrada)
        {
            var relatorio = new List<RelatorioComissaoDto>();

            // Validação simples para evitar erro se o JSON vier vazio
            if (entrada == null || entrada.Vendas == null)
            {
                return relatorio;
            }

            // Agrupa por vendedor
            var vendasPorVendedor = entrada.Vendas.GroupBy(v => v.Vendedor);

            foreach (var grupo in vendasPorVendedor)
            {
                decimal totalComissao = 0;
                decimal totalVendas = 0;

                foreach (var venda in grupo)
                {
                    totalVendas += venda.Valor;
                    // Chama a regra de negócio que está no Domain
                    totalComissao += _calculadoraService.Calcular(venda.Valor);
                }

                relatorio.Add(new RelatorioComissaoDto
                {
                    Vendedor = grupo.Key,
                    TotalVendas = totalVendas,
                    TotalComissao = totalComissao
                });
            }

            return relatorio;
        }
    }
}