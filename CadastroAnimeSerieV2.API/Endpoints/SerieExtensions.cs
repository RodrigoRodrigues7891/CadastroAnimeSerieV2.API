using CadastroAnimeSerieV2.API.DTO.Request;
using CadastroAnimeSerieV2.API.DTO.Response;
using CadastroAnimeSerieV2.Dados.Banco;
using CadastroAnimeSerieV2.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAnimeSerieV2.API.Endpoints;

public static class SerieExtensions
{
    public static void AddEndPointsSerie(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("serie")
            .WithTags("Serie");

        #region Endpoint Serie

        groupBuilder.MapGet("", ([FromServices] DAL<Serie> dalSerie) =>
        {
            var listaDeSeries = dalSerie.Listar();
            if (listaDeSeries is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(SerieResponse.EntityListToResponseList(listaDeSeries));
        }).WithSummary("Retorna todas as séries");

        groupBuilder.MapGet("{id}", ([FromServices] DAL<Serie> dalSerie, int id) =>
        {
            var serie = dalSerie.RecuperarPor(a => a.Id == id);
            if (serie is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(SerieResponse.EntityToResponse(serie));
        }).WithSummary("Retorna uma série pelo id");

        groupBuilder.MapGet("nome/{nome}", ([FromServices] DAL<Serie> dalSerie, string nome) =>
        {
            var serie = dalSerie.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (serie is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(SerieResponse.EntityToResponse(serie));
        }).WithSummary("Retorna uma série pelo nome");

        groupBuilder.MapGet("paginado", async ([FromServices] DAL<Serie> dalSerie,
                                               [FromQuery] int pagina = 1,
                                               [FromQuery] int tamanhoPorPagina = 2) =>
        {
            var listaDeSerie = await dalSerie.ListarPaginado(pagina, tamanhoPorPagina);
            if (listaDeSerie is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(SerieResponse.EntityListToResponseList(listaDeSerie));
        }).WithSummary("Retorna uma lista paginada");

        groupBuilder.MapPost("", async ([FromServices] DAL<Serie> dalSerie, [FromBody] SerieRequest request) =>
        {
            var serie = new Serie(request.Nome, request.Sinopse, request.QuantidadeDeEpisodios, request.AnoDoLancamento, request.Diretor);

            await dalSerie.Adicionar(serie);
            return Results.Ok();
        }).WithSummary("Adiciona uma nova série. Campos obrigatórios: Nome | Sinópse");

        groupBuilder.MapPut("", async ([FromServices] DAL<Serie> dalSerie, [FromBody] SerieRequestEdit request) =>
        {
            var serieAAtualizar = dalSerie.RecuperarPor(a => a.Id == request.id);
            if (serieAAtualizar is null)
            {
                return Results.NotFound();
            }

            if (string.IsNullOrWhiteSpace(request.Nome) || string.IsNullOrWhiteSpace(request.Sinopse))
            {
                return Results.BadRequest("O Nome e a Sinopse devem ser informados");
            }

            serieAAtualizar.Nome = request.Nome;
            serieAAtualizar.Sinopse = request.Sinopse;
            serieAAtualizar.QuantidadeDeEpisodios = request.QuantidadeDeEpisodios;
            serieAAtualizar.AnoDoLancamento = request.AnoDoLancamento;
            serieAAtualizar.Diretor = request.Diretor;

            await dalSerie.Atualizar(serieAAtualizar);
            return Results.Ok();
        }).WithSummary("Altera uma série. Campos obrigatórios: Nome | Sinópse");

        groupBuilder.MapDelete("{id}", async ([FromServices] DAL<Serie> dalSerie, int id) =>
        {
            var serieADeletar = dalSerie.RecuperarPor(a => a.Id == id);
            if (serieADeletar is null)
            {
                return Results.NotFound();
            }

            await dalSerie.Deletar(serieADeletar);
            return Results.NoContent();
        }).WithSummary("Apaga uma série pelo id");
        #endregion
    }
}
