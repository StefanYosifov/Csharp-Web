namespace Eventmi.Core.Services
{
    using Eventmi.Core.Contracts;
    using Eventmi.Core.Models;
    using Eventmi.Infrastructure.Data;
    using Eventmi.Infrastructure.Data.Data_Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EventService : IEventmiService
    {
        private readonly EventmiDbContext context;
        public EventService(EventmiDbContext context)
        {
            this.context = context;
        }

        public async Task Add(EventModel eventModel)
        {
            var entity = new Event()
            {
                Name = eventModel.Name,
                Start = eventModel.Start,
                End = eventModel.End,
                Places = eventModel.Places,
            };

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventModel>> GetAll()
        {
            return await context.Events.Select(e=>new EventModel
            {
                Name=e.Name,
                Start=e.Start,
                End=e.End,
                Places=e.Places,
            }).ToListAsync();

        }

        public async Task<EventModel> GetEvent(int EventId)
        {
            Event entity = await context.Events.FirstOrDefaultAsync(e => e.Id == EventId);
            return new EventModel()
            {
                Name = entity.Name,
                Start=entity.Start,
                End=entity.End,
                Places=entity.Places,
            };
            
        }

        public Task Remove(int EventId)
        {
            throw new NotImplementedException();
        }

        public async Task Update(EventModel eventModel)
        {
            Event entity = context.Events.FirstOrDefault(e=>e.Id==eventModel.Id);

            if (entity == null)
            {
                return;
            }

            entity.Name = eventModel.Name;
            entity.Start = eventModel.Start;
            entity.End = eventModel.End;
            entity.Places = eventModel.Places;

            await context.SaveChangesAsync();

        }
    }
}
