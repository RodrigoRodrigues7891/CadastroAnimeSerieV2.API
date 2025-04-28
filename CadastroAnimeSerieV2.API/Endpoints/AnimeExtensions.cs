using CadastroAnimeSerieV2.API.DTO.Request;
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

        groupBuilder.MapPost("", async ([FromServices] DAL<Anime> dalAnime, [FromBody] AnimeRequest request) =>
        {
            var anime = new Anime(request.Nome, request.Sinopse, request.QuantidadeDeEpisodios, request.AnoDoLancamento, request.Diretor);

            await dalAnime.Adicionar(anime);
            return Results.Ok();
        }).WithSummary("Adiciona um novo anime. Campos obrigatórios: Nome | Sinópse");

        groupBuilder.MapPut("", async ([FromServices] DAL<Anime> dalAnime, [FromBody] AnimeRequestEdit request) =>
        {
            var animeAAtualizar = dalAnime.RecuperarPor(a => a.Id == request.id);
            if (animeAAtualizar is null)
            {
                return Results.NotFound();
            }

            if (string.IsNullOrWhiteSpace(request.Nome) || string.IsNullOrWhiteSpace(request.Sinopse))
            {
                return Results.BadRequest("O Nome e a Sinopse devem ser informados");
            }

            animeAAtualizar.Nome = request.Nome;
            animeAAtualizar.Sinopse = request.Sinopse;
            animeAAtualizar.QuantidadeDeEpisodios = request.QuantidadeDeEpisodios;
            animeAAtualizar.AnoDoLancamento = request.AnoDoLancamento;
            animeAAtualizar.Diretor = request.Diretor;

            await dalAnime.Atualizar(animeAAtualizar);
            return Results.Ok();
        }).WithSummary("Altera um anime. Campos obrigatórios: Nome | Sinópse");

        groupBuilder.MapDelete("{id}", async ([FromServices] DAL<Anime> dalAnime, int id) =>
        {
            var animeADeletar = dalAnime.RecuperarPor(a => a.Id == id);
            if (animeADeletar is null)
            {
                return Results.NotFound();
            }

            await dalAnime.Deletar(animeADeletar);
            return Results.NoContent();
        }).WithSummary("Apaga um anime pelo id");
        #endregion
    }
}
