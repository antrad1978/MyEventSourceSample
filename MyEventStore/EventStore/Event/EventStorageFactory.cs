using EventStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Event
{
    public class EventStorageFactory<T>
    {
        public static IEventStorage<T> GetDefaultEventStorage()
        {
            return new MongoEventStorage<T>();
        }
    }
}
