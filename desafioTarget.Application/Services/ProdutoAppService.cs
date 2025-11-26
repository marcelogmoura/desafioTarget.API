using desafioTarget.Application.Dtos;
using desafioTarget.Domain.Entities;
using desafioTarget.Domain.Interfaces.Repositories;

namespace desafioTarget.Application.Services
{
    public class ProdutoAppService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoAppService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        // Método 1: Carrega a lista gigante de produtos
        public async Task CarregarEstoqueInicial(CargaEstoqueDto carga)
        {
            if (carga.Produtos == null) return;

            foreach (var item in carga.Produtos)
            {
                // Verifica se já existe para não duplicar
                var produtoExistente = await _repository.ObterPorCodigoAsync(item.CodigoProduto);

                if (produtoExistente == null)
                {
                    // Cria a entidade de Domínio
                    var novoProduto = new Produto(item.CodigoProduto, item.DescricaoProduto, item.Estoque);
                    await _repository.AdicionarAsync(novoProduto);
                }
            }
        }

        // Método 2: Realiza a movimentação (Entrada/Saída)
        public async Task<int> RealizarMovimentacao(MovimentacaoDto dto)
        {
            // 1. Busca o produto no banco
            var produto = await _repository.ObterPorCodigoAsync(dto.CodigoProduto);
            if (produto == null)
                throw new Exception("Produto não encontrado na base de dados.");

            // 2. Converte a string "Entrada"/"Saida" para o Enum do Domínio
            if (!Enum.TryParse<TipoMovimentacao>(dto.Tipo, true, out var tipoEnum))
                throw new Exception("Tipo inválido. Use 'Entrada' ou 'Saida'.");

            // 3. Aplica a regra de negócio (Dominio) - lança erro se estoque ficar negativo
            produto.AtualizarEstoque(dto.Quantidade, tipoEnum);

            // 4. Cria o registro de histórico
            var historico = new MovimentacaoEstoque(dto.CodigoProduto, dto.Descricao, tipoEnum, dto.Quantidade);

            // 5. Salva tudo (Produto atualizado + Histórico)
            await _repository.RegistrarMovimentacaoAsync(historico);
            await _repository.AtualizarAsync(produto);

            return produto.Estoque; // Retorna o saldo final
        }
    }
}