using System.Text.Json.Serialization;

namespace desafioTarget.Application.Dtos
{
    public class CargaEstoqueDto
    {
        [JsonPropertyName("estoque")]
        public List<ProdutoDto> Produtos { get; set; } = new();
    }
}