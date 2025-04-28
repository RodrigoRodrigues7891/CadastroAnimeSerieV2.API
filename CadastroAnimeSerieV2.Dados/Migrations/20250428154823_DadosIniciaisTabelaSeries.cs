using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroAnimeSerieV2.Dados.Migrations
{
    /// <inheritdoc />
    public partial class DadosIniciaisTabelaSeries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserindo dados na tabela Series
            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Nome", "Sinopse", "QuantidadeDeEpisodios", "AnoDoLancamento", "Diretor" },
                values: new object[,]
                {
                    { 1, "Breaking Bad", "Walter White, um professor de química, se transforma em um mestre da fabricação de metanfetamina.", 62, 2008, "Vince Gilligan" },
                    { 2, "Stranger Things", "Grupo de crianças tenta desvendar mistérios envolvendo experimentos secretos e criaturas do outro mundo.", 34, 2016, "The Duffer Brothers" },
                    { 3, "Game of Thrones", "Vários clãs lutam pelo controle do trono dos Sete Reinos de Westeros.", 73, 2011, "David Benioff, D.B. Weiss" },
                    { 4, "The Crown", "A história da Rainha Elizabeth II e os eventos históricos que marcaram seu reinado.", 60, 2016, "Peter Morgan" },
                    { 5, "The Mandalorian", "Um caçador de recompensas do universo Star Wars embarca em uma missão para proteger uma criatura misteriosa.", 24, 2019, "Jon Favreau" },
                    { 6, "Friends", "Seis amigos enfrentam os altos e baixos da vida em Nova York, com muito humor e situações inesperadas.", 236, 1994, "David Crane, Marta Kauffman" },
                    { 7, "The Office", "Documentário falso sobre a vida de funcionários de um escritório, com destaque para o excêntrico chefe Michael Scott.", 201, 2005, "Greg Daniels" },
                    { 8, "Narcos", "A série segue a ascensão e queda de Pablo Escobar e o tráfico de cocaína na Colômbia.", 30, 2015, "Andrés Baiz, Andi Baiz" },
                    { 9, "Black Mirror", "Cada episódio traz uma história independente que explora os lados sombrios da tecnologia e da sociedade.", 22, 2011, "Charlie Brooker" },
                    { 10, "Peaky Blinders", "A série segue a família Shelby, uma gangue criminosa em Birmingham, na Inglaterra, no pós-Primeira Guerra Mundial.", 36, 2013, "Steven Knight" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover os dados inseridos na tabela Series durante o rollback
            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }
    }
}
