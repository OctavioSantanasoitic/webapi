namespace webapi.MeuApp.DTOs.Diretores;

public class DiretorListOutputGetAllDTO

{
    public int CurrentPage { get; init; }

    public int TotalItems { get; init; }

    public int TotalPages { get; init; }

    public List<DiretorDTOOutputGetAll> Items { get; init; }

}

public class DiretorDTOOutputGetAll
{

    public string Nome { get; set; }

    public long Id { get; set; }

    public DiretorDTOOutputGetAll(long id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}
