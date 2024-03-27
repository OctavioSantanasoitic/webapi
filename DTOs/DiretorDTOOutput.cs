

namespace webapi.DTOs
{
    public class DiretorDTOOutput
    {
        public string Nome { get; set; }

        public long Id { get; set; }

        public DiretorDTOOutput(long id, string nome)
        {
            Id = id;
            Nome = nome;
        }

    }
}