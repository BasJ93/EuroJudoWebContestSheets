using EuroJudoWebContestSheets.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuroJudoWebContestSheets.Database.Configurations;

public class ApiKeyLinkRoleConfiguration : IEntityTypeConfiguration<ApiKeyLinkRole>
{
    public void Configure(EntityTypeBuilder<ApiKeyLinkRole> builder)
    {
        builder.Property(l => l.ApiKeyId)
            .IsRequired();
        
        builder.Property(l => l.RoleId)
            .IsRequired();

        builder.HasOne(l => l.ApiKey)
            .WithMany()
            .HasForeignKey(l => l.ApiKeyId)
            .HasConstraintName($"FK_{nameof(ApiKey)}_{nameof(ApiKeyLinkRole)}")
            .IsRequired();
        
        builder.HasOne(l => l.Role)
            .WithMany()
            .HasForeignKey(l => l.RoleId)
            .HasConstraintName($"FK_{nameof(Role)}_{nameof(ApiKeyLinkRole)}")
            .IsRequired();
    }
}