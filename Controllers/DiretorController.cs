using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders.Composite;
using webapi.DTOs;
using webapi.DTOs.Diretores;
using webapi.Models;
using webapi.Services.Diretores;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class DiretorController : ControllerBase
{
    private readonly AplicattionDbContext _context;

    private readonly IDiretorService _diretorService;
    public DiretorController(AplicattionDbContext context, IDiretorService diretorService)
    {
        _context = context;
        _diretorService = diretorService;
    }

    /// <summary>
    /// Busca Diretor Pelo Id Específico
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<DiretorDTOOutputGetById>> GetByIdMovies(long id)
    {


        var diretor = await _diretorService.GetById(id);


        var idDiretor = new DiretorDTOOutputGetById(diretor.Id, diretor.Nome);

        return Ok(idDiretor);



    }
    /// <summary>
    /// Busca Todos os Diretores
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<DiretorDTOOutputGetAll>>> GetMovies()
    {
        var diretores = await _diretorService.GetDiretor();

        var outputDTOList = new List<DiretorDTOOutputGetAll>();


        foreach (Diretor diretor in diretores)
        {
            outputDTOList.Add(new DiretorDTOOutputGetAll(diretor.Id, diretor.Nome));
        }

        return outputDTOList;



    }

    /// <summary>
    /// Cria um diretor
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<DiretorDTOOutputPost>> Post(
        [FromBody] DiretorDTOInputPost diretorDTOInput
    )
    {

        var diretor = await _diretorService.CriaDiretor(new Diretor(diretorDTOInput.Nome));


        var diretorDTOOutput = new DiretorDTOOutputPost(diretor.Id, diretor.Nome);

        return Ok(diretorDTOOutput);


    }

    /// <summary>
    /// Altera Informações do Diretor
    /// </summary>
    [HttpPut("{id:int}")]

    public async Task<ActionResult<DiretorDTOOutputPut>> Put(
     [FromBody] DiretorDTOInputPut model,
     [FromRoute] int id,
     [FromServices] AplicattionDbContext context
     )
    {

        var diretor = await _diretorService.AtualizaDiretor(new Diretor(model.Nome), id);


        var diretorDTOOutput = new DiretorDTOOutputPut(diretor.Id, diretor.Nome);

        return Ok(diretorDTOOutput);


    }
    /// <summary>
    /// Deleta um diretor
    /// </summary>
    [HttpDelete("{id:int}")]

    public async Task<ActionResult> DeleteDiretor(
    [FromRoute] int id,
    [FromServices] AplicattionDbContext context
    )
    {

        await _diretorService.Exclui(id);
        return Ok("Diretor Excluído com Sucesso!");



    }



}