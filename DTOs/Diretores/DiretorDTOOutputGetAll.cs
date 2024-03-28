namespace webapi.DTOs.Diretores;

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
