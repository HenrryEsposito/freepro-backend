using FreePro.API.Model;
using Microsoft.EntityFrameworkCore;

namespace FreePro.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Meeting> Meetings { get; set; }
    }
}