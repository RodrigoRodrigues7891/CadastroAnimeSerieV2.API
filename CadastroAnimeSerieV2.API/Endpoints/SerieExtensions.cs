using CadastroAnimeSerieV2.API.DTO.Converter;
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

            return Results.Ok(DTOConverter.SerieEntityListToResponseList(listaDeSeries));
        });

        groupBuilder.MapGet("{id}", ([FromServices] DAL<Serie> dalSerie, int id) =>
        {
            var serie = dalSerie.RecuperarPor(a => a.Id == id);
            if (serie is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(DTOConverter.SerieEntityToResponse(serie));
        });

        groupBuilder.MapGet("nome/{nome}", ([FromServices] DAL<Serie> dalSerie, string nome) =>
        {
            var serie = dalSerie.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (serie is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(DTOConverter.SerieEntityToResponse(serie));
        });
        #endregion
    }
}
