using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStorage.Command
{
    public interface IEventPublisher<T>
    {
        void PublishAsync(Event<T> @event);
    }
}
