using CadastroAnimeSerieV2.API.DTO.Response;
using CadastroAnimeSerieV2.Modelos;

namespace CadastroAnimeSerieV2.API.DTO.Converter;

public static class DTOConverter
{
    #region Anime Converter
    public static ICollection<AnimeResponse> AnimeEntityListToResponseList(IEnumerable<Anime> listaDeAnimes)
    {
        return listaDeAnimes.Select(a => AnimeEntityToResponse(a)).ToList();
    }

    public static AnimeResponse AnimeEntityToResponse(Anime anime)
    {
        return new AnimeResponse(anime.Id, anime.Nome, anime.Sinopse, anime.AnoDoLancamento, anime.QuantidadeDeEpisodios, anime.Diretor);
    }
    #endregion
    #region Serie Converter
    public static ICollection<SerieResponse> SerieEntityListToResponseList(IEnumerable<Serie> listaDeSeries)
    {
        return listaDeSeries.Select(a => SerieEntityToResponse(a)).ToList();
    }

    public static SerieResponse SerieEntityToResponse(Serie serie)
    {
        return new SerieResponse(serie.Id, serie.Nome, serie.Sinopse, serie.AnoDoLancamento, serie.QuantidadeDeEpisodios, serie.Diretor);
    }
    #endregion
}
