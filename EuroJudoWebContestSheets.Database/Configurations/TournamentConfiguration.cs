using EuroJudoWebContestSheets.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuroJudoWebContestSheets.Database.Configurations;

public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
{
    public void Configure(EntityTypeBuilder<Tournament> builder)
    {
        builder.Property(t => t.Id)
            .IsRequired();

        builder.Property(t => t.TournamentName)
            .IsUnicode()
            .IsRequired();
    }
}