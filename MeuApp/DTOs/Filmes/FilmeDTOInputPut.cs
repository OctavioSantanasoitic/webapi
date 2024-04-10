using System;

namespace webapi.MeuApp.DTOs.Filmes;

public class FilmeDTOInputPut
{

    public string Titulo { get; set; }

    public DateTime Ano { get; set; }

    public string Genero { get; set; }

    public long DiretorId { get; set; }


    public FilmeDTOInputPut(string titulo, DateTime ano, string genero, long diretorId)
    {
        Titulo = titulo;
        Ano = ano;
        Genero = genero;
        DiretorId = diretorId;

    }



}