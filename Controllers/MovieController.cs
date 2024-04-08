using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.DTOs.Filmes;
using webapi.Models;
using webapi.Services.Filmes;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly AplicattionDbContext _context;
    private readonly IMovieService _movieService;
    public MovieController(AplicattionDbContext context, IMovieService movieService)
    {
        _context = context;
        _movieService = movieService;
    }
    /// <summary>
    /// Busca Todos os Filmes
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<FilmeListOutputGetAllDTO>> GetMovies(CancellationToken cancellationToken, int limit = 5, int page = 1)
    {
        return await _movieService.GetByPageAsync(limit, page, cancellationToken);


    }
    /// <summary>
    /// Busca o Filme pelo Id Específico
    /// </summary>
    [HttpGet("{id:int}")]

    public async Task<ActionResult<FilmeDTOOutputGetById>> GetByIdMovies(int id)
    {
        var filme = await _movieService.GetById(id);


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

        var filme = await _movieService.CriaFilme(new Filme(inputDTO.Titulo, inputDTO.Ano, inputDTO.Genero, inputDTO.DiretorId));


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
        var filme = await _movieService.AtualizaFilme(new Filme(inputDTO.Titulo, inputDTO.Ano, inputDTO.Genero, inputDTO.DiretorId), id);

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
        await _movieService.Exclui(id);
        return Ok("Filme Excluído com Sucesso!");

    }



}