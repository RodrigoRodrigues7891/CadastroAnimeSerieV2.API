using Microsoft.EntityFrameworkCore;

namespace CadastroAnimeSerieV2.Dados.Banco;

public class DAL<T> where T : class
{
    private readonly CadastroAnimeSerieV2Context context;

    public DAL(CadastroAnimeSerieV2Context context)
    {
        this.context = context;
    }

    public IEnumerable<T> Listar()
    {
        return context.Set<T>().ToList();
    }

    public async Task<IEnumerable<T>> ListarPaginado(int page, int pageSize)
    {
        if (page <= 0) page = 1;
        if (pageSize < 0) pageSize = 0;

        return await context.Set<T>()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task Adicionar(T objeto)
    {
        context.Set<T>().Add(objeto);
        await context.SaveChangesAsync();
    }
    public async Task Atualizar(T objeto)
    {
        context.Set<T>().Update(objeto);
        await context.SaveChangesAsync();
    }
    public async Task Deletar(T objeto)
    {
        context.Set<T>().Remove(objeto);
        await context.SaveChangesAsync();
    }

    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }
}
