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
            
            return Results.Ok(AnimeResponse.EntityListToResponseList(listaDeAnimes));
        }).WithSummary("Retorna todos os animes");

        groupBuilder.MapGet("{id}", ([FromServices] DAL<Anime> dalAnime, int id) =>
        {
            var anime = dalAnime.RecuperarPor(a => a.Id == id);
            if (anime is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(AnimeResponse.EntityToResponse(anime));
        }).WithSummary("Retorna um anime pelo id");

        groupBuilder.MapGet("nome/{nome}", ([FromServices] DAL<Anime> dalAnime, string nome) =>
        {
            var anime = dalAnime.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (anime is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(AnimeResponse.EntityToResponse(anime));
        }).WithSummary("Retorna um anime pelo nome");

        groupBuilder.MapGet("paginado", async ([FromServices] DAL<Anime> dalAnime,
                                               [FromQuery] int pagina = 1,
                                               [FromQuery] int tamanhoPorPagina = 2) =>
        {
            var listaDeAnime = await dalAnime.ListarPaginado(pagina, tamanhoPorPagina);
            if (listaDeAnime is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(AnimeResponse.EntityListToResponseList(listaDeAnime));
        }).WithSummary("Retorna uma lista paginada");


        #endregion
    }
}
