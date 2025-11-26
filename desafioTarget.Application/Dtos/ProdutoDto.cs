using System.Text.Json.Serialization;

namespace desafioTarget.Application.Dtos
{
    public class ProdutoDto
    {
        [JsonPropertyName("codigoProduto")]
        public int CodigoProduto { get; set; }

        [JsonPropertyName("descricaoProduto")]
        public string DescricaoProduto { get; set; } = string.Empty;

        [JsonPropertyName("estoque")]
        public int Estoque { get; set; }
    }
}