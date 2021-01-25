using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Contexts;

namespace Infrastructure.Data.Repositories
{
    public class GitHubRepository : Repository<GitHub>, IGitHubRepository
    {
        public GitHubRepository(DesafioSofiaContext context) : base(context) { }
    }
}
