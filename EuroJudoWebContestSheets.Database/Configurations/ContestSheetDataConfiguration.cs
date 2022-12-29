using EuroJudoWebContestSheets.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuroJudoWebContestSheets.Database.Configurations;

public class ContestSheetDataConfiguration : IEntityTypeConfiguration<ContestSheetData>
{
    public void Configure(EntityTypeBuilder<ContestSheetData> builder)
    {
        builder.Property(c => c.Id)
            .IsRequired();

        builder.Property(c => c.CategoryId)
            .IsRequired();

        builder.Property(c => c.TournamentId)
            .IsRequired();

        builder.Property(c => c.Contest)
            .IsRequired();

        builder.Property(c => c.CompetitorBlue)
            .IsUnicode()
            .IsRequired(false);
        
        builder.Property(c => c.CompetitorWhite)
            .IsUnicode()
            .IsRequired(false);

        builder.Property(c => c.IponBlue)
            .HasDefaultValue(0)
            .IsRequired(false);
        
        builder.Property(c => c.IponWhite)
            .HasDefaultValue(0)
            .IsRequired(false);
        
        builder.Property(c => c.WazaariBlue)
            .HasDefaultValue(0)
            .IsRequired(false);
        
        builder.Property(c => c.WazaariWhite)
            .HasDefaultValue(0)
            .IsRequired(false);
        
        builder.Property(c => c.ShidoBlue)
            .HasDefaultValue(0)
            .IsRequired(false);
        
        builder.Property(c => c.ShidoWhite)
            .HasDefaultValue(0)
            .IsRequired(false);

        builder.Property(c => c.ShowSimpleScore)
            .IsRequired();

        builder.HasOne<Tournament>(c => c.Tournament)
            .WithMany()
            .HasForeignKey(c => c.TournamentId)
            .HasConstraintName($"FK_{nameof(Tournament)}_{nameof(ContestSheetData)}");

        builder.HasOne<Category>(c => c.Category)
            .WithMany(ca => ca.SheetData)
            .HasForeignKey(c => c.CategoryId)
            .HasConstraintName($"FK_{nameof(Category)}_{nameof(ContestSheetData)}");
    }
}