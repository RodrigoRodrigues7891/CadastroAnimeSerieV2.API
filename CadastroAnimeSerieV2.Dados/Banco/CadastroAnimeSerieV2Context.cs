using CadastroAnimeSerieV2.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CadastroAnimeSerieV2.Dados.Banco;

public class CadastroAnimeSerieV2Context : DbContext
{
    public DbSet<Anime> Animes { get; set; }
    public DbSet<Serie> Series { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CadastroAnimeSerieV2;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public CadastroAnimeSerieV2Context()
    {

    }
    public CadastroAnimeSerieV2Context(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies();
    }
}
