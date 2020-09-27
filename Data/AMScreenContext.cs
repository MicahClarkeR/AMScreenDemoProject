using Microsoft.EntityFrameworkCore;
using AMScreenInterview.Models.Entities;

namespace AMScreenInterview.Data
{
    public class AMScreenContext : DbContext
    {
        public AMScreenContext(DbContextOptions<AMScreenContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EngineerJobs>()
                .HasKey(x => new { x.EngineerId, x.IssueId });

            modelBuilder.Entity<ScreenIssues>()
                .HasKey(x => new { x.IssueId, x.ScreenId });
        }

        public DbSet<Engineer> Engineer { get; set; }
        public DbSet<EngineerJobs> EngineerJobs { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<Screen> Screen { get; set; }
        public DbSet<ScreenIssues> ScreenIssues { get; set; }
    }
}
