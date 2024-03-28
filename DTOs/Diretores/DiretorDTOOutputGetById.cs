namespace webapi.DTOs.Diretores;

public class DiretorDTOOutputGetById
{
    public string Nome { get; private set; }

    public long Id { get; private set; }


    public DiretorDTOOutputGetById(long id, string nome)
    {

        Id = id;
        Nome = nome;
    }

}