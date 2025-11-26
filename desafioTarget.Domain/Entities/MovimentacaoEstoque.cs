using System;

namespace desafioTarget.Domain.Entities
{
    public class MovimentacaoEstoque
    {
        public Guid Id { get; private set; }  
        public int CodigoProduto { get; private set; }
        public string Descricao { get; private set; }  
        public TipoMovimentacao Tipo { get; private set; }
        public int Quantidade { get; private set; }
        public DateTime DataMovimentacao { get; private set; }

        public MovimentacaoEstoque(int codigoProduto, string descricao, TipoMovimentacao tipo, int quantidade)
        {
            Id = Guid.NewGuid();
            CodigoProduto = codigoProduto;
            Descricao = descricao;
            Tipo = tipo;
            Quantidade = quantidade;
            DataMovimentacao = DateTime.Now;
        }
    }

    public enum TipoMovimentacao
    {
        Entrada = 1,
        Saida = 2
    }
}