using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroAnimeSerieV2.Dados.Migrations
{
    /// <inheritdoc />
    public partial class DadosIniciaisTabelaAnimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserindo dados na tabela Animes
            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "Id", "Nome", "Sinopse", "QuantidadeDeEpisodios", "AnoDoLancamento", "Diretor" },
                values: new object[,]
                {
                    { 1, "Naruto", "Um jovem ninja busca reconhecimento e sonha se tornar Hokage.", 220, 2002, "Hayato Date" },
                    { 2, "One Piece", "Monkey D. Luffy e sua tripulação em busca do tesouro One Piece.", 1000, 1999, "Konosuke Uda" },
                    { 3, "Death Note", "Um estudante encontra um caderno com o poder de matar pessoas.", 37, 2006, "Tetsuro Araki" },
                    { 4, "Attack on Titan", "Humanidade luta contra gigantes devoradores.", 87, 2013, "Tetsuro Araki" },
                    { 5, "Fullmetal Alchemist: Brotherhood", "Dois irmãos buscam a Pedra Filosofal para recuperar seus corpos.", 64, 2009, "Yasuhiro Irie" },
                    { 6, "Dragon Ball Z", "Goku protege a Terra de poderosos inimigos.", 291, 1989, "Daisuke Nishio" },
                    { 7, "Bleach", "Ichigo Kurosaki se torna um Shinigami para proteger os vivos dos espíritos malignos.", 366, 2004, "Noriyuki Abe" },
                    { 8, "Demon Slayer", "Tanjiro luta contra demônios para salvar sua irmã.", 26, 2019, "Haruo Sotozaki" },
                    { 9, "Tokyo Ghoul", "Um jovem vira meio-ghoul e precisa sobreviver nesse novo mundo.", 12, 2014, "Shuhei Morita" },
                    { 10, "My Hero Academia", "Em um mundo onde quase todos têm superpoderes, um garoto sem poderes sonha ser herói.", 138, 2016, "Kenji Nagasaki" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover os dados inseridos na tabela Animes durante o rollback
            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }
    }
}
