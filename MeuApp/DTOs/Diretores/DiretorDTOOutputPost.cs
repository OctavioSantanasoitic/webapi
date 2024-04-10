

namespace webapi.MeuApp.DTOs.Diretores
{
    public class DiretorDTOOutputPost
    {
        public string Nome { get; set; }

        public long Id { get; set; }

        public DiretorDTOOutputPost(long id, string nome)
        {
            Id = id;
            Nome = nome;
        }

    }
}