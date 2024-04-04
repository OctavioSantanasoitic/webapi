using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.DTOs.Diretores;
using webapi.Models;


namespace webapi.Services.Diretores;

public class DiretorService : IDiretorService
{

    private readonly AplicattionDbContext _context;
    public DiretorService(AplicattionDbContext context)
    {
        _context = context;

    }

    public async Task<List<Diretor>> GetDiretor()
    {
        var diretores = await _context.Diretores.ToListAsync();

        if (!diretores.Any())
            throw new Exception("Não Existem Diretores Cadastrados");

        return diretores;


    }

    public async Task<Diretor> GetById(long id)
    {
        var idDiretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);

        if (idDiretor == null)
            throw new ArgumentNullException("Diretor Não encontrado!");

        return idDiretor;
    }

    public async Task<Diretor> CriaDiretor(Diretor diretor)
    {
        _context.Diretores.Add(diretor);
        await _context.SaveChangesAsync();

        return diretor;
    }

    public async Task<Diretor> AtualizaDiretor(Diretor diretor, long id)
    {
        var idDiretor = await _context.Diretores.AsNoTracking()
                                                .FirstOrDefaultAsync(diretor => diretor.Id == id);

        if (idDiretor == null)
            throw new Exception("Id do Diretor não existe");


        diretor.Id = id;
        _context.Diretores.Update(diretor);
        await _context.SaveChangesAsync();

        return diretor;
    }

    public async Task Exclui(long id)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);
        _context.Diretores.Remove(diretor);
        await _context.SaveChangesAsync();

    }


}