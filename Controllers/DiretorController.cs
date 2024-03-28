using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders.Composite;
using webapi.DTOs;
using webapi.DTOs.Diretores;
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
    public async Task<ActionResult<DiretorDTOOutputGetById>> GetByIdMovies(long id)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(d => d.Id == id);

        var idDiretor = new DiretorDTOOutputGetById(diretor.Id, diretor.Nome);

        return Ok(idDiretor);


    }

    [HttpGet]
    public async Task<List<DiretorDTOOutputGetAll>> GetMovies()
    {
        var diretores = await _context.Diretores.ToListAsync();

        var outputDTOList = new List<DiretorDTOOutputGetAll>();

        foreach (Diretor diretor in diretores)
        {
            outputDTOList.Add(new DiretorDTOOutputGetAll(diretor.Id, diretor.Nome));
        }

        return outputDTOList;
    }

    [HttpPost]

    public async Task<ActionResult<DiretorDTOOutputPost>> Post(
        [FromBody] DiretorDTOInputPost diretorDTOInput
    )
    {
        var diretor = new Diretor(diretorDTOInput.Nome);
        _context.Diretores.Add(diretor);
        await _context.SaveChangesAsync();


        var diretorDTOOutput = new DiretorDTOOutputPost(diretor.Id, diretor.Nome);

        return Ok(diretorDTOOutput);
    }

    [HttpPut("{id:int}")]

    public async Task<ActionResult<DiretorDTOOutputPut>> Put(
     [FromBody] DiretorDTOInputPut model,
     [FromRoute] int id,
     [FromServices] AplicattionDbContext context
     )
    {
        var diretor = new Diretor(model.Nome);

        diretor.Id = id;
        context.Diretores.Update(diretor);
        await context.SaveChangesAsync();

        var diretorDTOOutput = new DiretorDTOOutputPut(diretor.Id, diretor.Nome);

        return Ok(diretorDTOOutput);

    }

    [HttpDelete("{id:int}")]

    public async Task<ActionResult> DeleteDiretor(
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