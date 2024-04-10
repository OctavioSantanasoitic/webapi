using Microsoft.AspNetCore.Http.HttpResults;

namespace webapi.MeuApp.Models;

public class Diretor
{
    public string Nome { get; set; }

    public long Id { get; set; }

    public ICollection<Filme> Filmes { get; set; } //ICOLLECTION -> LISTA DE ALGO

    public Diretor(string nome)
    {
        Nome = nome;
        Filmes = new List<Filme>();
    }


}