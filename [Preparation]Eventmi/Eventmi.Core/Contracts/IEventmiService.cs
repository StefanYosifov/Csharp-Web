namespace Eventmi.Core.Contracts
{
    using Eventmi.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEventmiService
    {

        public Task Add(EventModel eventModel);

        public Task Remove(int EventId);

        public Task Update(EventModel eventModel);
        public Task<IEnumerable<EventModel>> GetAll(); 

        public Task<EventModel> GetEvent(int EventId);
    }
}
