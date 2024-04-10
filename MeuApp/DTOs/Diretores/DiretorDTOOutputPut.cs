namespace webapi.MeuApp.DTOs.Diretores;

public class DiretorDTOOutputPut
{
    public DiretorDTOOutputPut(long id, string nome)
    {
        Id = id;
        Nome = nome;
    }
    public string Nome { get; set; }

    public long Id { get; set; }



}