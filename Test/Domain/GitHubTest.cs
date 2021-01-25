using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Domain
{
    [TestClass]
    public class GitHubTest
    {
        private GitHubService _service;
        private Mock<IMapper> _mockMapper;
        private Mock<IGitHubRepository> _mockGitHubRepository;
        private IEnumerable<GitHub> _gitHubs;
        private List<GitHubViewModel> _gitHubsViewModel;

        [TestInitialize]
        public void Setup()
        {
            _mockMapper = new Mock<IMapper>();
            _mockGitHubRepository = new Mock<IGitHubRepository>();
            _service = new GitHubService(_mockMapper.Object, _mockGitHubRepository.Object);

            _gitHubs = new List<GitHub>
            {
                new GitHub(1, 12345, "NomeGit01", "https://github.com/", "C#", "Descrição do Git 01", DateTime.Now, "Vinícius Batista", false),
                new GitHub(2, 32566, "NomeGit02", "https://github.com/", "VB", "Descrição do Git 02", DateTime.Now.AddDays(-15), "Reginaldo Rossi", true)
            };

            _gitHubsViewModel = new List<GitHubViewModel>
            {
                new GitHubViewModel{Id = 1, IdGitHub = 12345, Nome="NomeGit01", URL = "https://github.com/", Linguagem = "C#", Descricao = "Descrição do Git 01", DtAtualizacao=DateTime.Now, DonoRepositorio = "Vinícius Batista", Favorito=false },
                new GitHubViewModel{Id = 2, IdGitHub = 32566, Nome="NomeGit02", URL = "https://github.com/", Linguagem = "VB", Descricao = "Descrição do Git 02", DtAtualizacao=DateTime.Now.AddDays(-15), DonoRepositorio = "Reginaldo Rossi", Favorito=true },
            };
        }

        [TestMethod]
        public async Task BuscarRepositoriosTest()
        {
            // Arrange
            _mockGitHubRepository.Setup(x => x.GetAsync())
              .Returns(Task.FromResult(_gitHubs));

            _mockMapper.Setup(x => x.Map<IEnumerable<GitHubViewModel>>(_gitHubs))
               .Returns(_gitHubsViewModel);

            // Act
            var result = await _service.BuscarRepositorios();

            // Assert
            Assert.IsTrue(result.Count() == 2);
        }

        [TestMethod]
        public async Task BuscarRepositoriosFavoritosTest()
        {
            // Arrange
            _mockGitHubRepository.Setup(x => x.SearchAsync(x => x.Favorite))
              .Returns(Task.FromResult(_gitHubs));

            _mockMapper.Setup(x => x.Map<IEnumerable<GitHubViewModel>>(_gitHubs))
               .Returns(_gitHubsViewModel.Where(x => x.Favorito));

            // Act
            var result = await _service.BuscarRepositoriosFavoritos();

            // Assert
            Assert.IsTrue(result.Count() == 1);
        }

        [TestMethod]
        public async Task DetalharRepositorioTest()
        {
            // Arrange
            var gitHub = _gitHubs.FirstOrDefault(x => x.Id == 1);
            var gitHubsViewModel = _gitHubsViewModel.FirstOrDefault(x => x.Id == 1);

            _mockGitHubRepository.Setup(x => x.GetByIdAsync(1))
             .Returns(Task.FromResult(gitHub));

            _mockMapper.Setup(x => x.Map<GitHubViewModel>(gitHub))
               .Returns(gitHubsViewModel);

            // Act
            var result = await _service.DetalharRepositorio(1);

            // Assert
            Assert.IsTrue(result.Id == 1);
        }

        [TestMethod]
        public async Task MarcarRepositorioFavoritoTest()
        {
            // Arrange
            var gitHub = _gitHubs.FirstOrDefault(x => x.Id == 1);
            var favorite = gitHub.Favorite;

            _mockGitHubRepository.Setup(x => x.GetByIdAsync(1))
                .Returns(Task.FromResult(gitHub));

            // Act
            await _service.MarcarRepositorioFavorito(1);

            // Assert
            Assert.IsTrue(gitHub.Favorite == !favorite);
        }

        [TestMethod]
        public async Task ProcurarRepositoriosTest()
        {
            // Arrange
            var nome = "NomeGit02";
            var gitHubs = _gitHubs.Where(x => x.Name.ToLower().Contains(nome.ToLower()));
            var gitHubsViewModel = _gitHubsViewModel.Where(x => x.Nome.ToLower().Contains(nome.ToLower()));

            _mockGitHubRepository.Setup(x => x.SearchAsync(x => x.Name.ToLower().Contains(nome.ToLower())))
             .Returns(Task.FromResult(gitHubs));

            _mockMapper.Setup(x => x.Map<IEnumerable<GitHubViewModel>>(gitHubs))
               .Returns(gitHubsViewModel);

            // Act
            var result = await _service.ProcurarRepositorios(nome);

            // Assert
            Assert.IsTrue(result.Count() == 1);
        }
    }
}
