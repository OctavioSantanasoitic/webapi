using Microsoft.EntityFrameworkCore;
using webapi.DTOs.Filmes;
using webapi.Models;

namespace webapi.Services.Filmes;

public class MovieService : IMovieService
{
    private readonly AplicattionDbContext _context;

    public MovieService(AplicattionDbContext context)
    {
        _context = context;
    }
    public async Task<FilmeListOutputGetAllDTO> GetByPageAsync(int limit, int page, CancellationToken cancellationToken)
    {
        var pagedModel = await _context.Filmes
                .AsNoTracking()
                .Include(filme => filme.Diretor)
                .OrderBy(p => p.Id)
                .PaginateAsync(page, limit, cancellationToken);

        if (!pagedModel.Items.Any())
        {
            throw new Exception("Não existem diretores cadastrados!");
        }

        return new FilmeListOutputGetAllDTO
        {
            CurrentPage = pagedModel.CurrentPage,
            TotalPages = pagedModel.TotalPages,
            TotalItems = pagedModel.TotalItems,
            Items = pagedModel.Items.Select(filme => new FilmeDTOOutputGetByAll(filme.Id, filme.Titulo, filme.Ano, filme.Genero, filme.DiretorId, filme.Diretor.Nome)).ToList()
        };

    }
    public async Task<Filme> GetById(long id)
    {
        var idFilme = await _context.Filmes.Include(filme => filme.Diretor)
                                            .FirstOrDefaultAsync(x => x.Id == id);

        if (idFilme == null)
            throw new ArgumentNullException("Filme Não encontrado!");

        return idFilme;
    }

    public async Task<Filme> CriaFilme(Filme filmes)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == filmes.DiretorId);

        if (diretor == null)
        {
            throw new Exception("Id do Diretor não existe");
        }

        _context.Filmes.Add(filmes);
        await _context.SaveChangesAsync();

        return filmes;
    }

    public async Task<Filme> AtualizaFilme(Filme filme, int id)
    {

        var idDiretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == filme.DiretorId);

        if (idDiretor == null)
            throw new Exception("Id do Diretor não existe");

        var idFilme = await _context.Filmes.AsNoTracking()
                                           .FirstOrDefaultAsync(filme => filme.Id == id);

        if (idFilme == null)
            throw new Exception("Id do Filme não existe");


        if (filme.DiretorId == 0)
            throw new Exception("Id do Diretor Invalido");

        filme.Id = id;

        _context.Filmes.Update(filme);
        await _context.SaveChangesAsync();

        return filme;

    }

    public async Task Exclui(long id)
    {
        var idFilme = await _context.Filmes.Include(filme => filme.Diretor)
                                     .FirstOrDefaultAsync(filme => filme.Id == id);

        if (idFilme == null)
            throw new Exception("Id do Filme não existe");

        _context.Filmes.Remove(idFilme);
        await _context.SaveChangesAsync();


    }
}