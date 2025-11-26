using System.Text.Json.Serialization;

namespace desafioTarget.Application.Dtos
{
    // Mapeia o JSON: { "vendas": [ ... ] }
    public class ListaVendasDto
    {
        [JsonPropertyName("vendas")]
        public List<VendaDto> Vendas { get; set; } = new();
    }

    // Mapeia cada item da lista
    public class VendaDto
    {
        [JsonPropertyName("vendedor")]
        public string Vendedor { get; set; } = string.Empty;

        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }
    }

    // DTO de Saída (Resposta da API)
    public class RelatorioComissaoDto
    {
        public string Vendedor { get; set; } = string.Empty;
        public decimal TotalVendas { get; set; }
        public decimal TotalComissao { get; set; }
    }
}