namespace desafioTarget.Domain.Services
{
    public class CalculadoraComissaoService
    {
        private const decimal VALOR_MINIMO_COMISSAO = 100.00m; 
        private const decimal VALOR_FAIXA_ALTA = 500.00m; 

        private const decimal PERCENTUAL_BAIXO = 0.01m; // 1% 
        private const decimal PERCENTUAL_ALTO = 0.05m; // 5% 

        public decimal Calcular(decimal valorVenda)
        {
            // venda abaixo de R$100,00 - não gera comissão
            if (valorVenda < VALOR_MINIMO_COMISSAO)
                return 0;

            // venda abaixo de R$500,00 - 1% de comissão
            if (valorVenda < VALOR_FAIXA_ALTA)
                return valorVenda * PERCENTUAL_BAIXO;

            // acima de R$500,00 - 5% de comissão 
            return valorVenda * PERCENTUAL_ALTO;
        }
    }
}