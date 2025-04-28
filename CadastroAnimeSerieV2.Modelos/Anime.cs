namespace CadastroAnimeSerieV2.Modelos;

public class Anime
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sinopse { get; set; }
    public int? QuantidadeDeEpisodios { get; set; }
    public int? AnoDoLancamento { get; set; }
    public string? Diretor { get; set; }
}
