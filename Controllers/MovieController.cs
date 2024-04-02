using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.DTOs.Filmes;
using webapi.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly AplicattionDbContext _context;
    public MovieController(AplicattionDbContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Busca Todos os Filmes
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<FilmeDTOOutputGetByAll>>> GetMovies()
    {
        var filmes = await _context.Filmes.Include(filme => filme.Diretor)
                                          .ToListAsync();

        var infoFilmes = new List<FilmeDTOOutputGetByAll>();

        foreach (Filme filme in filmes)
        {
            var getFilmes = new FilmeDTOOutputGetByAll(
                filme.Id, filme.Titulo, filme.Ano, filme.Genero, filme.DiretorId, filme.Diretor.Nome);

            infoFilmes.Add(getFilmes);

        }

        if (!infoFilmes.Any())
            return NotFound("Não existem filmes cadastrados!");

        return infoFilmes;
    }
    /// <summary>
    /// Busca o Filme pelo Id Específico
    /// </summary>
    [HttpGet("{id:int}")]

    public async Task<ActionResult<FilmeDTOOutputGetById>> GetByIdMovies(int id)
    {
        var filme = await _context.Filmes.Include(filme => filme.Diretor)
                                         .FirstOrDefaultAsync(x => x.Id == id);


        if (filme == null)
            throw new ArgumentNullException("Filme Não encontrado!");


        var outpuDTO = new FilmeDTOOutputGetById(
            filme.Id, filme.Titulo, filme.Ano, filme.Genero, filme.DiretorId, filme.Diretor.Nome);

        return Ok(outpuDTO);
    }
    /// <summary>
    /// Cria um Filme
    /// </summary>
    [HttpPost]

    public async Task<ActionResult<FilmeDTOOutputPost>> Post(
        [FromBody] FilmeDTOInputPost inputDTO
    )
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == inputDTO.DiretorId);

        if (diretor == null)
        {
            return Conflict("Id do Diretor não existe");
        }

        var filme = new Filme(inputDTO.Titulo, inputDTO.Ano, inputDTO.Genero, inputDTO.DiretorId);
        _context.Filmes.Add(filme);
        await _context.SaveChangesAsync();

        var filmeDTOOutput = new FilmeDTOOutputPost(filme.Id, filme.Titulo, filme.Ano, filme.Genero, filme.DiretorId);

        return Ok(filmeDTOOutput);
    }
    /// <summary>
    /// Altera Informações do Filme
    /// </summary>
    [HttpPut("{id:int}")]

    public async Task<ActionResult<FilmeDTOOutputPut>> Put(
     [FromRoute] int id,
     [FromBody] FilmeDTOInputPut inputDTO
     )
    {
        var filme = new Filme(inputDTO.Titulo, inputDTO.Ano, inputDTO.Genero, inputDTO.DiretorId);

        if (inputDTO.DiretorId == 0)
        {
            return Conflict("Id do Diretor Invalido");
        }

        filme.Id = id;

        _context.Filmes.Update(filme);
        await _context.SaveChangesAsync();


        var outputDto = new FilmeDTOOutputPut(filme.Id, filme.Titulo, filme.Ano, filme.Genero, filme.DiretorId);

        return Ok(outputDto);

    }
    /// <summary>
    ///Deleta o Filme
    /// </summary>
    [HttpDelete("{id:int}")]

    public async Task<ActionResult<FilmeDTOOutputDelete>> DeleteFilme(
    [FromRoute] int id
    )
    {
        var filme = await _context.Filmes.Include(filme => filme.Diretor)
                                         .FirstOrDefaultAsync(x => x.Id == id);

        if (filme == null)
        {
            return Conflict("Id do Filme não existe");
        }

        _context.Filmes.Remove(filme);
        await _context.SaveChangesAsync();

        var outpuDTO = new FilmeDTOOutputDelete(filme.Id, filme.Titulo, filme.Ano, filme.Genero, filme.DiretorId, filme.Diretor.Nome);

        return Ok(filme);

    }



}