using EventStorage.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.PubSub
{
    public class PubSubFactory<T>
    {
        public static IEventPublisher<T> GetDefault()
        {
            return new RabbitMQEventManager<T>();
        }
    }
}
