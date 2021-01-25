using Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGitHubService
    {
        Task CarregarRepositorioBaseDeDados(string repositorioUsuario);
        Task<IEnumerable<GitHubViewModel>> BuscarRepositorios();
        Task<IEnumerable<GitHubViewModel>> ProcurarRepositorios(string nomeRepositorio);
        Task<IEnumerable<GitHubViewModel>> BuscarRepositoriosFavoritos();
        Task<GitHubViewModel> DetalharRepositorio(int id);
        Task MarcarRepositorioFavorito(int id);
    }
}
