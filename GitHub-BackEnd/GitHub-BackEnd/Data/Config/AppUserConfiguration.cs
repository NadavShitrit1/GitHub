using GitHub_BackEnd.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GitHub_BackEnd.Data.Config
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.PasswordSalt).IsRequired();
            builder.Property(p => p.PasswordHash).IsRequired();
            builder.Property(p => p.Username).IsRequired();
            builder.HasMany(b => b.GitHubRepositories)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
