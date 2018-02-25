using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStorage
{
    public interface IEventStorage<T>
    {
        IEnumerable<Event<T>> GetEvents(int start, int count);
        //Task<IEnumerable<Event<T>> GetEventsAsync(Tpe aggregateType, int start, int count);
        Task<Event<T>> GetLastEventAsync(Type aggregateType, Guid aggregateId);
        void CommitChangesAsync(Event<T> @event);
    }
}
