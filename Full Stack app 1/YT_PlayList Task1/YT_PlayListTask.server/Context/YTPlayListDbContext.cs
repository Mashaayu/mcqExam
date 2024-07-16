using Microsoft.EntityFrameworkCore;
using YTPlaylist.Server.Model;

namespace YTPlaylist.Server.Context
{
    public class YTPlayListDbContext:DbContext
    {
        private readonly IConfiguration configuration;

        public YTPlayListDbContext(DbContextOptions<YTPlayListDbContext> dbContextOptions, IConfiguration configuration)
            :base(dbContextOptions)
        {
            this.configuration = configuration;
        }


        public DbSet<PlayList> PlayList { get; set; }
        public DbSet<Video> Video { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"));
        }
        
    }
}
