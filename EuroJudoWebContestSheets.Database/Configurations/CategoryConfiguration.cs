using EuroJudoWebContestSheets.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuroJudoWebContestSheets.Database.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Id)
            .IsRequired();

        builder.Property(c => c.TournamentId)
            .IsRequired();

        builder.Property(c => c.SheetSize)
            .IsRequired();

        builder.Property(c => c.Short)
            .IsUnicode()
            .IsRequired();
        
        builder.Property(c => c.Weight)
            .IsUnicode()
            .IsRequired();
        
        builder.Property(c => c.CategoryName)
            .IsUnicode()
            .IsRequired();
        
        builder.HasOne<Tournament>(c => c.Tournament)
            .WithMany(t => t.Categories)
            .HasForeignKey(c => c.TournamentId)
            .HasConstraintName($"FK_{nameof(Tournament)}_{nameof(Category)}");
    }
}