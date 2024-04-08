using webapi.DTOs.Diretores;
using webapi.Models;

namespace webapi.Services.Diretores;

public interface IDiretorService
{
    Task<DiretorListOutputGetAllDTO> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);

    Task<Diretor> GetById(long id);

    Task<Diretor> CriaDiretor(Diretor diretor);

    Task<Diretor> AtualizaDiretor(Diretor diretor, long id);

    Task Exclui(long id);
}