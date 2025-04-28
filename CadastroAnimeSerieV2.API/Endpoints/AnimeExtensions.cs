using CadastroAnimeSerieV2.API.DTO.Converter;
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
            
            return Results.Ok(DTOConverter.AnimeEntityListToResponseList(listaDeAnimes));
        });

        groupBuilder.MapGet("{id}", ([FromServices] DAL<Anime> dalAnime, int id) =>
        {
            var anime = dalAnime.RecuperarPor(a => a.Id == id);
            if (anime is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(DTOConverter.AnimeEntityToResponse(anime));
        });

        groupBuilder.MapGet("nome/{nome}", ([FromServices] DAL<Anime> dalAnime, string nome) =>
        {
            var anime = dalAnime.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (anime is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(DTOConverter.AnimeEntityToResponse(anime));
        });
        #endregion
    }
}
