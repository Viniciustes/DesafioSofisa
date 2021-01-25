using System;

namespace Application.ViewModels
{
    public class GitHubViewModel
    {
        public int Id { get; set; }
        public int IdGitHub { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public string Linguagem { get; set; }
        public string Descricao { get; set; }
        public bool Favorito { get; set; }
        public DateTime DtAtualizacao { get; set; }
        public string DonoRepositorio { get; set; }
    }
}
