using CadastroAnimeSerieV2.Modelos;

namespace CadastroAnimeSerieV2.API.DTO.Response;

public record SerieResponse(int Id, string Nome, string Sinopse, int? AnoDoLancamento, int? QuantidadeDeEpisodios, string? Diretor)
{
    #region Serie Converter
    public static ICollection<SerieResponse> EntityListToResponseList(IEnumerable<Serie> listaDeSeries)
    {
        return listaDeSeries.Select(a => EntityToResponse(a)).ToList();
    }

    public static SerieResponse EntityToResponse(Serie serie)
    {
        return new SerieResponse(serie.Id, serie.Nome, serie.Sinopse, serie.AnoDoLancamento, serie.QuantidadeDeEpisodios, serie.Diretor);
    }
    #endregion
}