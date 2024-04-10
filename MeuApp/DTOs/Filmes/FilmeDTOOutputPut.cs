using System;

namespace webapi.MeuApp.DTOs.Filmes;

public class FilmeDTOOutputPut
{

    public int Id { get; set; }
    public string Titulo { get; set; }

    public DateTime Ano { get; set; }

    public string Genero { get; set; }

    public long DiretorId { get; set; }


    public FilmeDTOOutputPut(int id, string titulo, DateTime ano, string genero, long diretorId)
    {
        Id = id;
        Titulo = titulo;
        Ano = ano;
        Genero = genero;
        DiretorId = diretorId;
    }



}