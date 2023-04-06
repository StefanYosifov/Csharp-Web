namespace Eventmi.Infrastructure.Data
{
    using Eventmi.Infrastructure.Data.Common;
    using Eventmi.Infrastructure.Data.Data_Models;
    using Microsoft.EntityFrameworkCore;
 
    public class EventmiDbContext:DbContext
    {
        public EventmiDbContext()
        {
                
        }


        public EventmiDbContext(DbContextOptions<EventmiDbContext> options)
            :base(options)
        {

        }

        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.ConnectionString);
            }
        }

    }
}
