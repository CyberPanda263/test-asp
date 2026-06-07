using Microsoft.EntityFrameworkCore;
using TestAsp.Models;

namespace TestAsp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RecordItem> Records { get; set; }
    }
}