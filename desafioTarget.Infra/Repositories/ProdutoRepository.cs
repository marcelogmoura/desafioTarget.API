using desafioTarget.Domain.Entities;
using desafioTarget.Domain.Interfaces.Repositories;
using desafioTarget.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace desafioTarget.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DesafioContext _context;

        public ProdutoRepository(DesafioContext context)
        {
            _context = context;
        }

        public async Task<Produto?> ObterPorCodigoAsync(int codigoProduto)
        {
            
            return await _context.Produtos
                .FirstOrDefaultAsync(p => p.CodigoProduto == codigoProduto);
        }

        public async Task AdicionarAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task RegistrarMovimentacaoAsync(MovimentacaoEstoque movimentacao)
        {
            await _context.Movimentacoes.AddAsync(movimentacao);
            await _context.SaveChangesAsync();
        }
    }
}