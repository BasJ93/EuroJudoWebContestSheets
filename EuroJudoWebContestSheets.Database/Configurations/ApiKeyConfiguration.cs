using EuroJudoWebContestSheets.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuroJudoWebContestSheets.Database.Configurations;

public class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKey>
{
    public void Configure(EntityTypeBuilder<ApiKey> builder)
    {
        builder.Property(a => a.Id)
            .IsRequired();

        builder.Property(a => a.Key)
            .IsRequired();

        builder.Property(a => a.Created)
            .IsRequired();

        builder.Property(a => a.Owner)
            .IsRequired();

        builder.HasMany<Role>(a => a.Roles)
            .WithMany(r => r.ApiKeys)
            .UsingEntity<ApiKeyLinkRole>();
    }
}