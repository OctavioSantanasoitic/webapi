using webapi.Models;

namespace webapi.Services.Diretores;

public interface IDiretorService
{
    Task<List<Diretor>> GetDiretor();
    Task<Diretor> GetById(long id);

    Task<Diretor> CriaDiretor(Diretor diretor);

    Task<Diretor> AtualizaDiretor(Diretor diretor, long id);

    Task Exclui(long id);
}