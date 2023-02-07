using GitHub_BackEnd.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GitHub_BackEnd.Data.Config
{
    public class GitHubRepositoryConfiguration : IEntityTypeConfiguration<GitHubRepository>
    {
        public void Configure(EntityTypeBuilder<GitHubRepository> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.GitHubId);
            builder.Property(p => p.name).IsRequired();
            builder.HasOne(b => b.User).WithMany()
                .HasForeignKey(p => p.UserId);
        }
    }
}
