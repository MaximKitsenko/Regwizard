using Microsoft.EntityFrameworkCore;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository.Memory
{
    public class RegwizContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }

        //protected ChattingContext()
        //{
        //    this.ChangeTracker.AutoDetectChangesEnabled = false;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=chattingdb");
            //optionsBuilder.UseSqlServer("Server=DESKTOP-CAURBOF;Database=chattingdb;Trusted_Connection=True;");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}