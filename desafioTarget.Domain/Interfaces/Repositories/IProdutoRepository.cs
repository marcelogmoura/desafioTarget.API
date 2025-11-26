using desafioTarget.Domain.Entities;

namespace desafioTarget.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto?> ObterPorCodigoAsync(int codigoProduto);
        Task AdicionarAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
        Task RegistrarMovimentacaoAsync(MovimentacaoEstoque movimentacao);
    }
}
