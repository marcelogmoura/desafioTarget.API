namespace desafioTarget.Domain.Entities
{
    public class Produto
    {
        public int Id { get; private set; }  
        public int CodigoProduto { get; private set; }  
        public string DescricaoProduto { get; private set; }
        public int Estoque { get; private set; }

        
        protected Produto() { }

        public Produto(int codigoProduto, string descricaoProduto, int estoqueInicial)
        {
            CodigoProduto = codigoProduto;
            DescricaoProduto = descricaoProduto;
            Estoque = estoqueInicial;
        }

        public void AtualizarEstoque(int quantidade, TipoMovimentacao tipo)
        {
            if (tipo == TipoMovimentacao.Entrada)
            {
                Estoque += quantidade;
            }
            else
            {
                if (Estoque < quantidade)
                    throw new DomainException("Estoque insuficiente para esta saída.");

                Estoque -= quantidade;
            }
        }
    }
}