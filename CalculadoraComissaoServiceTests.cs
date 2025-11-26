using desafioTarget.Domain.Services;
using Xunit;

namespace desafioTarget.Tests
{
    public class CalculadoraComissaoServiceTests
    {
        private readonly CalculadoraComissaoService _service;

        public CalculadoraComissaoServiceTests()
        {
            _service = new CalculadoraComissaoService();
        }

        [Theory]
        [InlineData(90, 0)]      // Abaixo de 100 -> 0 comissão
        [InlineData(99.99, 0)]   // Limite inferior
        public void Deve_Retornar_Zero_Para_Vendas_Abaixo_De_100(decimal valorVenda, decimal comissaoEsperada)
        {
            var resultado = _service.Calcular(valorVenda);
            Assert.Equal(comissaoEsperada, resultado);
        }

        [Theory]
        [InlineData(100, 1.00)]  // 100 * 1% = 1.00
        [InlineData(499.99, 4.9999)] // Quase 500 * 1%
        public void Deve_Calcular_1_Porcento_Para_Vendas_Entre_100_e_500(decimal valorVenda, decimal comissaoEsperada)
        {
            var resultado = _service.Calcular(valorVenda);
            Assert.Equal(comissaoEsperada, resultado);
        }

        [Theory]
        [InlineData(500, 25)]    // 500 * 5% = 25
        [InlineData(1000, 50)]   // 1000 * 5% = 50
        public void Deve_Calcular_5_Porcento_Para_Vendas_Acima_De_500(decimal valorVenda, decimal comissaoEsperada)
        {
            var resultado = _service.Calcular(valorVenda);
            Assert.Equal(comissaoEsperada, resultado);
        }
    }
}