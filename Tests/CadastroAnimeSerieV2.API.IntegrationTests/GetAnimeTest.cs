using CadastroAnimeSerieV2.Modelos;
using System.Net.Http.Json;

namespace CadastroAnimeSerieV2.Test.API.Integration
{
    public class GetAnimeTest : IClassFixture<CadastroAnimeSerieV2WebApplicationFactory>
    {
        private readonly CadastroAnimeSerieV2WebApplicationFactory app;

        public GetAnimeTest(CadastroAnimeSerieV2WebApplicationFactory app)
        {
            this.app = app;
        }

        [Fact]
        public async Task Recupera_Lista_Anime()
        {
            //Arrange
            var quantidadeAnimes = app.Context.Animes.Count();

            using var client = app.CreateClient();
            //Act

            var response = await client.GetFromJsonAsync<ICollection<Anime>>("/anime");

            //Assert
            Assert.Equal(quantidadeAnimes, response.Count());

        }

        [Fact]
        public async Task Recupera_Por_Id_Anime()
        {
            //Arrange
            var anime = app.Context.Animes.FirstOrDefault();

            using var client = app.CreateClient();
            //Act
            var response = await client.GetFromJsonAsync<Anime>($"/anime/{anime.Id}");

            //Assert
            Assert.Equal(anime.Id, response.Id);

        }

        [Fact]
        public async Task Recupera_Por_Nome_Anime()
        {
            //Arrange
            var anime = app.Context.Animes.FirstOrDefault();

            using var client = app.CreateClient();

            //Act
            var response = await client.GetFromJsonAsync<Anime>($"anime/nome/{anime.Nome}");

            //Assert
            Assert.Equal(anime.Sinopse, anime.Sinopse);
        }

        [Fact]
        public async Task Recuperar_Animes_Na_Consulta_Paginada()
        {
            //Arrange
            int pagina = 1;
            int tamanhoPorPagina = 2;

            using var client = app.CreateClient();
            //Act
            var response = await client.GetFromJsonAsync<ICollection<Anime>>
                ($"/Anime/Paginado?pagina={pagina}&tamanhoPorPagina={tamanhoPorPagina}");
            //var reponseTodas = await client.GetFromJsonAsync<ICollection<Anime>>("/ofertas-viagem/todas");
            //Assert
            Assert.True(response != null);
            Assert.Equal(tamanhoPorPagina, response.Count());

        }

        // outros

        [Fact]
        public async Task Recuperar_Animes_Na_Consulta_Paginada_Quantidade_Ultima_Pagina()
        {
            //Arrange
            int pagina = 4;
            int tamanhoPorPagina = 3;

            using var client = app.CreateClient();
            //Act
            var response = await client.GetFromJsonAsync<ICollection<Anime>>
                ($"/Anime/Paginado?pagina={pagina}&tamanhoPorPagina={tamanhoPorPagina}");

            //Assert
            Assert.True(response != null);
            Assert.Equal(1, response.Count());

        }

        [Fact]
        public async Task Recuperar_Animes_Na_Consulta_Paginada_Pagina_Com_Valor_Negativo()
        {
            //Arrange
            int pagina = -8;
            int tamanhoPorPagina = 5;

            using var client = app.CreateClient();
            //Act
            var response = await client.GetFromJsonAsync<ICollection<Anime>>
                ($"/Anime/Paginado?pagina={pagina}&tamanhoPorPagina={tamanhoPorPagina}");

            //Assert
            Assert.True(response != null);
            Assert.Equal(5, response.Count());

        }

        [Fact]
        public async Task Recuperar_Animes_Na_Consulta_Paginada_Pagina_Com_Valor_Zero()
        {
            //Arrange
            int pagina = 0;
            int tamanhoPorPagina = 5;

            using var client = app.CreateClient();
            //Act
            var response = await client.GetFromJsonAsync<ICollection<Anime>>
                ($"/Anime/Paginado?pagina={pagina}&tamanhoPorPagina={tamanhoPorPagina}");

            //Assert
            Assert.True(response != null);
            Assert.Equal(5, response.Count());

        }

        [Fact]
        public async Task Recuperar_Animes_Na_Consulta_Paginada_Tamanho_Por_Pagina_Com_Valor_Negativo()
        {
            //Arrange
            int pagina = 1;
            int tamanhoPorPagina = -50;

            using var client = app.CreateClient();
            //Act
            var response = await client.GetFromJsonAsync<ICollection<Anime>>
                ($"/Anime/Paginado?pagina={pagina}&tamanhoPorPagina={tamanhoPorPagina}");

            //Assert
            Assert.True(response != null);
            Assert.Equal(0, response.Count());

        }

        [Fact]
        public async Task Recuperar_Animes_Na_Consulta_Paginada_Tamanho_Por_Pagina_Com_Valor_Zero()
        {
            //Arrange
            int pagina = 1;
            int tamanhoPorPagina = 0;

            using var client = app.CreateClient();
            //Act
            var response = await client.GetFromJsonAsync<ICollection<Anime>>
                ($"/Anime/Paginado?pagina={pagina}&tamanhoPorPagina={tamanhoPorPagina}");

            //Assert
            Assert.True(response != null);
            Assert.Equal(0, response.Count());

        }
    }
}
