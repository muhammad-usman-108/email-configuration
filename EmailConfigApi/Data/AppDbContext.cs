using Microsoft.EntityFrameworkCore;
using EmailConfigApi.Models;

namespace EmailConfigApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<EmailConfiguration> EmailConfigurations { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<EmailConfiguration>()
                .Property(e => e.Provider)
                .HasConversion<string>()
                .HasMaxLength(20);

            // optional seed
            builder.Entity<EmailConfiguration>().HasData(
                new EmailConfiguration {
                    Id = 1,
                    Name = "Example Exchange",
                    WatchedFolder = "/inbox/exchange",
                    Provider = ProviderType.Exchange,
                    StoreAttachments = true
                }
            );
        }
    }
}
