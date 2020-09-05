using GTSharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GTSharp.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Node> Node { get; set; }
        public DbSet<Recomendation> Recomendation { get; set; }
        public DbSet<RoadMap> RoadMap { get; set; }
        public DbSet<Subtitle> Subtitle { get; set; }
        public DbSet<User> User { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}