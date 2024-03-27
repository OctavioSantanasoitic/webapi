using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    [HttpGet]
    public async Task<List<Filme>> GetMovies()
    {
        return await _context.Filmes.ToListAsync();
    }

    [HttpPost]

    public async Task<ActionResult<Filme>> Post(
        [FromBody] Filme filme
    )
    {
        _context.Filmes.Add(filme);
        await _context.SaveChangesAsync();

        return Ok(filme);
    }

    [HttpPut]

    public async Task<IActionResult> Put(
     [FromBody] Filme model,
     [FromServices] AplicattionDbContext context
     )
    {
        var filme = await context.Filmes.FirstOrDefaultAsync(x => x.Id == model.Id);

        filme.Titulo = model.Titulo;

        context.Filmes.Update(filme);
        await context.SaveChangesAsync();

        return Ok(filme);

    }

    [HttpDelete]

    public async Task<IActionResult> DeleteFilme(
    [FromBody] Filme model,
    [FromServices] AplicattionDbContext context
    )
    {
        var filme = await context.Filmes.FirstOrDefaultAsync(x => x.Id == model.Id);

        context.Filmes.Remove(filme);
        await context.SaveChangesAsync();

        return Ok(filme);

    }



}