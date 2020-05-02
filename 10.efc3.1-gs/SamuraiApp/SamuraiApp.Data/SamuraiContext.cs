using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }

        private static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter((category, logLevel) =>
                        category == DbLoggerCategory.Database.Command.Name
                            && logLevel == LogLevel.Information)
                .AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .UseSqlServer("Data Source=127.0.0.1;Initial Catalog=ef-core;User Id=SA;Password=P2ssw0rdP2ssw0rd");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // For many-to-many relationships   
            modelBuilder
                .Entity<SamuraiBattle>()
                .HasKey(s => new { s.SamuraiId, s.BattleId });

            // For controling the table name
            modelBuilder
                .Entity<Horse>()
                .ToTable("Horses");
        }
    }
}