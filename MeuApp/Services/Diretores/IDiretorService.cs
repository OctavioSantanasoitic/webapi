using webapi.MeuApp.DTOs.Diretores;
using webapi.MeuApp.Models;

namespace webapi.MeuApp.Services.Diretores;

public interface IDiretorService
{
    Task<DiretorListOutputGetAllDTO> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);

    Task<Diretor> GetById(long id);

    Task<Diretor> CriaDiretor(Diretor diretor);

    Task<Diretor> AtualizaDiretor(Diretor diretor, long id);

    Task Exclui(long id);
}