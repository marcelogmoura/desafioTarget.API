using desafioTarget.Domain.Services;
using Xunit;

namespace desafioTarget.Tests
{
    public class CalculadoraJurosServiceTests
    {
        [Fact]
        public void Deve_Calcular_Juros_Corretamente_Quando_Estiver_Atrasado()
        {
            // Arrange
            var service = new CalculadoraJurosService();
            decimal valorOriginal = 1000m;
            // Simula vencimento 10 dias atrás a partir de hoje
            DateTime dataVencimento = DateTime.Today.AddDays(-10);

            // Regra: 1000 * 2.5% (0.025) * 10 dias = 250 de juros. Total esperado: 1250.
            decimal valorEsperado = 1250m;

            // Act
            var resultado = service.CalcularValorComJuros(valorOriginal, dataVencimento);

            // Assert
            Assert.Equal(valorEsperado, resultado);
        }

        [Fact]
        public void Nao_Deve_Cobrar_Juros_Se_Nao_Estiver_Atrasado()
        {
            // Arrange
            var service = new CalculadoraJurosService();
            decimal valorOriginal = 1000m;
            DateTime dataVencimento = DateTime.Today.AddDays(1); // Vence amanhã

            // Act
            var resultado = service.CalcularValorComJuros(valorOriginal, dataVencimento);

            // Assert
            Assert.Equal(valorOriginal, resultado);
        }
    }
}