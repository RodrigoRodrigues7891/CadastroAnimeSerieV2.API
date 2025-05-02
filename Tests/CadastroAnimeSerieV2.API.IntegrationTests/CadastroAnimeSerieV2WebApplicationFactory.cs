using CadastroAnimeSerieV2.Dados.Banco;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroAnimeSerieV2.Test.API.Integration;

public class CadastroAnimeSerieV2WebApplicationFactory : WebApplicationFactory<Program>
{
    public CadastroAnimeSerieV2Context Context { get; }
    private IServiceScope scope;

    public CadastroAnimeSerieV2WebApplicationFactory()
    {
        this.scope = Services.CreateScope();
        Context = scope.ServiceProvider.GetRequiredService<CadastroAnimeSerieV2Context>();
    }
}
