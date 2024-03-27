using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders.Composite;
using webapi.DTOs;
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

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DiretorDTOInput>> GetByIdMovies(long id)
    {
        var idDiretor = await _context.Diretores.FindAsync(id);

        if (idDiretor == null)
            return NotFound("Id do Diretor não encontrado");

        return Ok(idDiretor);


    }

    [HttpGet]
    public async Task<List<Diretor>> GetMovies()
    {
        return await _context.Diretores.ToListAsync();
    }

    [HttpPost]

    public async Task<ActionResult<DiretorDTOOutput>> Post(
        [FromBody] DiretorDTOInput diretorDTOInput
    )
    {
        var diretor = new Diretor(diretorDTOInput.Nome);
        _context.Diretores.Add(diretor);
        await _context.SaveChangesAsync();


        var diretorDTOOutput = new DiretorDTOOutput(diretor.Id, diretor.Nome);

        return Ok(diretorDTOOutput);
    }

    [HttpPut("{id:int}")]

    public async Task<ActionResult<DiretorDTOOutput>> Put(
     [FromBody] DiretorDTOInput model,
     [FromRoute] int id,
     [FromServices] AplicattionDbContext context
     )
    {
        var diretor = await context.Diretores.FirstOrDefaultAsync(x => x.Id == id);

        diretor.Nome = model.Nome;

        context.Diretores.Update(diretor);
        await context.SaveChangesAsync();

        return Ok(diretor);

    }

    [HttpDelete("{id:int}")]

    public async Task<ActionResult<DiretorDTOInput>> DeleteDiretor(
    [FromRoute] int id,
    [FromServices] AplicattionDbContext context
    )
    {
        var diretor = await context.Diretores.FirstOrDefaultAsync(x => x.Id == id);

        context.Diretores.Remove(diretor);
        await context.SaveChangesAsync();

        return Ok(diretor);

    }



}