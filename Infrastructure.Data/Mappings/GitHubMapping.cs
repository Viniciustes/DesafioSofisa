using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings
{
    class GitHubMapping : IEntityTypeConfiguration<GitHub>
    {
        public void Configure(EntityTypeBuilder<GitHub> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("GitHub");

            builder.Property(x => x.Id);

            builder.Property(x => x.IdGitHub);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.URL)
              .HasColumnType("varchar(100)")
              .HasMaxLength(100);

            builder.Property(x => x.Language)
              .HasColumnType("varchar(100)")
              .HasMaxLength(100);

            builder.Property(x => x.Description)
              .HasColumnType("varchar(100)")
              .HasMaxLength(100);

            builder.Property(x => x.DtAtualizacao)
              .HasColumnType("Date");

            builder.Property(x => x.Favorite)
             .HasColumnType("bit");
        }
    }
}
