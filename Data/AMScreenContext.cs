using Microsoft.EntityFrameworkCore;
using AMScreenInterview.Models.Entities;

namespace AMScreenInterview.Data
{
    public class AMScreenContext : DbContext
    {
        public AMScreenContext(DbContextOptions<AMScreenContext> options) : base(options)
        {
        }

        public DbSet<Screen> Screen { get; set; }
    }
}
