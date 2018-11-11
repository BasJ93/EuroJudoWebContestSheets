using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroJudoWebContestSheets.Models
{
    public class dbContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContestSheetData> ContestSheetData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=EuroJudoWebContent.db");
        }
    }
}
