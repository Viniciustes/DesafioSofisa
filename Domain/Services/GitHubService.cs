using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class GitHubService : IGitHubService
    {
        private const string ApiGitHubURL = "https://api.github.com";

        private readonly IMapper _mapper;
        private readonly IGitHubRepository _repository;

        public GitHubService(IMapper mapper, IGitHubRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CarregarRepositorioBaseDeDados(string repositorioUsuario)
        {
            await LimpaBaseDeDados();

            var URL = $"{ApiGitHubURL}/users/{repositorioUsuario}/repos";

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

            var response = await httpClient.GetAsync(URL);

            var result = await response.Content.ReadAsStringAsync();

            var gitHub = JsonConvert.DeserializeObject<List<GitHub>>(result);

            await _repository.AddRanger(gitHub);
        }

        public async Task<IEnumerable<GitHubViewModel>> BuscarRepositorios()
        {
            var entities = await _repository.GetAsync();

            return _mapper.Map<IEnumerable<GitHubViewModel>>(entities.OrderBy(x => x.Name));
        }

        public async Task<IEnumerable<GitHubViewModel>> BuscarRepositoriosFavoritos()
        {
            var entities = await _repository.SearchAsync(x => x.Favorite);

            return _mapper.Map<IEnumerable<GitHubViewModel>>(entities.OrderBy(x => x.Name));
        }

        public async Task<GitHubViewModel> DetalharRepositorio(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                return null;

            return _mapper.Map<GitHubViewModel>(entity);
        }

        public async Task MarcarRepositorioFavorito(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                return;

            entity.ToogleBookmark();

            _repository.Update(entity);
        }

        public async Task<IEnumerable<GitHubViewModel>> ProcurarRepositorios(string nomeRepositorio)
        {
            var entities = await _repository.SearchAsync(x => x.Name.ToLower().Contains(nomeRepositorio.ToLower()));

            return _mapper.Map<IEnumerable<GitHubViewModel>>(entities.OrderBy(x => x.Name));
        }

        /// <summary>
        /// Limpa base caso já tenha realizado um carregamento de repositório
        /// </summary>
        /// <returns></returns>
        private async Task LimpaBaseDeDados()
        {
            var entities = await _repository.GetAsync();
            if (entities.Any())
            {
                _repository.RemoveAsync(entities);
            }
        }
    }
}