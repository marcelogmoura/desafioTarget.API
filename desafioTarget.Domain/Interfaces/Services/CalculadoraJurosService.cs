using System;

namespace desafioTarget.Domain.Services
{
    public class CalculadoraJurosService
    {
        private const decimal TAXA_MULTA_DIARIA = 0.025m; // 2,5% 

        public decimal CalcularValorComJuros(decimal valorOriginal, DateTime dataVencimento)
        {
            var dataHoje = DateTime.Today; 

            if (dataHoje <= dataVencimento)
                return valorOriginal;

            var diasAtraso = (dataHoje - dataVencimento).Days;
                        
            var valorMulta = valorOriginal * TAXA_MULTA_DIARIA * diasAtraso;

            return valorOriginal + valorMulta;
        }
    }
}