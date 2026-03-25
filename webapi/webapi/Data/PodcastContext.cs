using Microsoft.EntityFrameworkCore;

namespace webapi.Data
{
    public class PodcastContext : DbContext
    {
        public PodcastContext(DbContextOptions<PodcastContext> options) : base(options)
        {
        }

        public DbSet<Podcast> Podcasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Podcast>().HasData(
                new Podcast { Id = 1, Title = "Syntax", Host = "Wes Bos & Scott Tolinski", LaunchYear = 2017 },
                new Podcast { Id = 2, Title = "Darknet Diaries", Host = "Jack Rhysider", LaunchYear = 2017 },
                new Podcast { Id = 3, Title = "Developer Tea", Host = "Jonathan Cutrell", LaunchYear = 2015 }
            );
        }
    }
}
