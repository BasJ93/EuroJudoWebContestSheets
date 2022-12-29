using EuroJudoWebContestSheets.Database.Configurations;
using EuroJudoWebContestSheets.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EuroJudoWebContestSheets.Database
{
    public class ContestSheetDbContext : DbContext
    {
        public DbSet<Tournament> Tournaments => Set<Tournament>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<ContestSheetData> ContestSheetData => Set<ContestSheetData>();

        public DbSet<ApiKey> ApiKeys => Set<ApiKey>();
        public DbSet<Role> Roles => Set<Role>();

        public DbSet<ApiKeyLinkRole> ApiKeyLinkRoles => Set<ApiKeyLinkRole>();
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=EuroJudoWebContent.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TournamentConfiguration).Assembly);
        }
    }
}
