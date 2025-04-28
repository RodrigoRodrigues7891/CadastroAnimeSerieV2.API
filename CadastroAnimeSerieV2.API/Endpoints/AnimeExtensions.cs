using CadastroAnimeSerieV2.API.DTO.Response;
using CadastroAnimeSerieV2.Dados.Banco;
using CadastroAnimeSerieV2.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAnimeSerieV2.API.Endpoints;

public static class AnimeExtensions
{
    public static void AddEndPointsAnime(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("anime")
            .WithTags("Anime");

        #region Endpoint Anime

        groupBuilder.MapGet("", ([FromServices] DAL<Anime> dalAnime) =>
        {
            var listaDeAnimes = dalAnime.Listar();
            if (listaDeAnimes is null)
            {
                return Results.NotFound();
            }

            //return Results.Ok(listaDeAnimes);
            return Results.Ok(EntityListToResponseList(listaDeAnimes));
        });

        #endregion
    }

    private static ICollection<AnimeResponse> EntityListToResponseList(IEnumerable<Anime> listaDeAnimes)
    {
        return listaDeAnimes.Select(a => EntityToResponse(a)).ToList();
    }

    private static AnimeResponse EntityToResponse(Anime anime)
    {
        return new AnimeResponse(anime.Id, anime.Nome, anime.Sinopse, anime.AnoDoLancamento, anime.QuantidadeDeEpisodios, anime.Diretor);
    }
}
