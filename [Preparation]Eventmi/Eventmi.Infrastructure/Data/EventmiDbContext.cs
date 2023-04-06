namespace Eventmi.Infrastructure.Data
{
    using Eventmi.Infrastructure.Data.Common;
    using Microsoft.EntityFrameworkCore;
 
    internal class EventmiDbContext:DbContext
    {
        public EventmiDbContext()
        {
                
        }


        public EventmiDbContext(DbContextOptions<EventmiDbContext> options)
            :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.ConnectionString);
            }
        }

    }
}
