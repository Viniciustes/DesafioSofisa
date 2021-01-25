using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioSofisa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : BaseController
    {
        private readonly IGitHubService _service;

        public GitHubController(IGitHubService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{repositorioUsuario}")]
        public async Task<IActionResult> CarregarRepositorioBaseDeDados(string repositorioUsuario)
        {
            await _service.CarregarRepositorioBaseDeDados(repositorioUsuario);

            return Response(new { });
        }

        [HttpGet]
        public async Task<IActionResult> BuscarRepositorios()
        {
            return Response(await _service.BuscarRepositorios());
        }

        [HttpGet]
        [Route("Favoritos")]
        public async Task<IActionResult> BuscarRepositoriosFavoritos()
        {
            return Response(await _service.BuscarRepositoriosFavoritos());
        }

        [HttpGet]
        [Route("Procurar/{nomeRepositorio}")]
        public async Task<IActionResult> ProcurarRepositorios(string nomeRepositorio)
        {
            return Response(await _service.ProcurarRepositorios(nomeRepositorio));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> DetalharRepositorio(int id)
        {
            return Response(await _service.DetalharRepositorio(id));
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> MarcarRepositorioFavorito(int id)
        {
            await _service.MarcarRepositorioFavorito(id);

            return Response(new { });
        }
    }
}
