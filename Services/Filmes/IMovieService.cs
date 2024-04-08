using webapi.DTOs.Filmes;
using webapi.Models;

namespace webapi.Services.Filmes;

public interface IMovieService
{
    Task<FilmeListOutputGetAllDTO> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);
    Task<Filme> GetById(long id);

    Task<Filme> CriaFilme(Filme filme);

    Task<Filme> AtualizaFilme(Filme filme, int id);

    Task Exclui(long id);
}