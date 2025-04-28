namespace CadastroAnimeSerieV2.API.DTO.Request;

public record AnimeRequestEdit(int id, string Nome, string Sinopse, int? QuantidadeDeEpisodios, int? AnoDoLancamento, string? Diretor);