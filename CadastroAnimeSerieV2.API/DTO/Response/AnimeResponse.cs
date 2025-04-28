using CadastroAnimeSerieV2.Modelos;

namespace CadastroAnimeSerieV2.API.DTO.Response;

public record AnimeResponse(int Id, string Nome, string Sinopse, int? AnoDoLancamento, int? QuantidadeDeEpisodios, string? Diretor)
{
    #region Anime Converter
    public static ICollection<AnimeResponse> EntityListToResponseList(IEnumerable<Anime> listaDeAnimes)
    {
        return listaDeAnimes.Select(a => EntityToResponse(a)).ToList();
    }

    public static AnimeResponse EntityToResponse(Anime anime)
    {
        return new AnimeResponse(anime.Id, anime.Nome, anime.Sinopse, anime.AnoDoLancamento, anime.QuantidadeDeEpisodios, anime.Diretor);
    }
    #endregion
}