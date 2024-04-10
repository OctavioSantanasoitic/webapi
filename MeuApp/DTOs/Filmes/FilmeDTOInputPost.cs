using System;

namespace webapi.MeuApp.DTOs.Filmes;

public class FilmeDTOInputPost
{

    public string Titulo { get; set; }

    public DateTime Ano { get; set; }

    public string Genero { get; set; }

    public long DiretorId { get; set; }

    public FilmeDTOInputPost(string titulo, DateTime ano, string genero, long diretorId)
    {
        Titulo = titulo;
        Ano = ano;
        Genero = genero;
        DiretorId = diretorId;
    }



}