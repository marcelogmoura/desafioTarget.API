namespace desafioTarget.Application.Dtos
{
    public class MovimentacaoDto
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty; // "Entrada" ou "Saida"
        public int Quantidade { get; set; }
    }
}