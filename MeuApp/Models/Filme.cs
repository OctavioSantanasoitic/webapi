namespace webapi.MeuApp.Models;

public class Filme
{


    public int Id { get; set; }
    public string Titulo { get; set; }

    public DateTime Ano { get; set; }

    public string Genero { get; set; }

    public long DiretorId { get; set; }

    public Diretor Diretor { get; set; }


    public Filme(string titulo, DateTime ano, string genero, long diretorId)
    {
        Titulo = titulo;
        Ano = ano;
        Genero = genero;
        DiretorId = diretorId;

    }





}