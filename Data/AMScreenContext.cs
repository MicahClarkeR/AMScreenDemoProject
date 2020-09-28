using Microsoft.EntityFrameworkCore;
using AMScreenInterview.Models.Entities;

namespace AMScreenInterview.Data
{
    public class AMScreenContext : DbContext
    {
        public AMScreenContext(DbContextOptions<AMScreenContext> options) : base(options)
        {
        }

        /// <summary>
        /// Set up the database model, using fluent API to set up primary and composite keys
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set up screenissue composite key, shared amongst IssueId and ScreenId
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
