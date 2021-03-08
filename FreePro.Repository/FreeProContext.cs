using Microsoft.EntityFrameworkCore;
using FreePro.Domain;

namespace FreePro.Repository
{
    public class FreeProContext : DbContext
    {
        public FreeProContext(DbContextOptions<FreeProContext> options) : base (options) {}
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Hoster> Hosters { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<HosterMeeting> HosterMeetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<HosterMeeting>()
                .HasKey(PE => new { PE.MeetingId, PE.HosterId });
        }
    }
}