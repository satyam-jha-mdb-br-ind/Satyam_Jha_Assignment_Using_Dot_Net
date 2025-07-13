namespace Flipers.Data
{
    using Flipers.Models;
    using Flipers.Models;
    using Flipers.Models;
    using Microsoft.EntityFrameworkCore;

    namespace ProClientHub.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Project> Projects { get; set; }
            public DbSet<Client> Clients { get; set; }
            public DbSet<ContactForm> ContactForms { get; set; }
            public DbSet<Subscription> Subscriptions { get; set; }
        }
    }

}
