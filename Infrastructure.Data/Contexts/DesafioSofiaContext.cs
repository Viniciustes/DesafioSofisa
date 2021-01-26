using Domain.Models;
using Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Contexts
{
    public class DesafioSofiaContext : DbContext
    {
        public DesafioSofiaContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<GitHub> GitHub { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GitHubMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}