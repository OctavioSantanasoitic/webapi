using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders.Composite;
using webapi.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class DiretorController : ControllerBase
{
    private readonly AplicattionDbContext _context;
    public DiretorController(AplicattionDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Diretor>> GetMovies()
    {
        return await _context.Diretores.ToListAsync();
    }

    [HttpPost]

    public async Task<ActionResult<Diretor>> Post(
        [FromBody] Diretor diretor
    )
    {
        _context.Diretores.Add(diretor);
        await _context.SaveChangesAsync();

        return Ok(diretor);
    }

    [HttpPut]

    public async Task<IActionResult> Put(
     [FromBody] Diretor model,
     [FromServices] AplicattionDbContext context
     )
    {
        var diretor = await context.Diretores.FirstOrDefaultAsync(x => x.Id == model.Id);

        diretor.Nome = model.Nome;

        context.Diretores.Update(diretor);
        await context.SaveChangesAsync();

        return Ok(diretor);

    }

    [HttpDelete]

    public async Task<IActionResult> DeleteDiretor(
    [FromBody] Diretor model,
    [FromServices] AplicattionDbContext context
    )
    {
        var diretor = await context.Diretores.FirstOrDefaultAsync(x => x.Id == model.Id);

        context.Diretores.Remove(diretor);
        await context.SaveChangesAsync();

        return Ok(diretor);

    }



}