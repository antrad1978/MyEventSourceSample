using EventStorage;
using EventStorage.Command;
using EventStore.PubSub;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStorage
{
    public class MongoEventStorage<T> : IEventStorage<T>
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase db;
        private const string Db = "tutorial";

        MongoCredential mongoCredential = MongoCredential.CreateMongoCRCredential("tutorial",
                            "user", "password");
        MongoClientSettings mongoClientSettings = new MongoClientSettings
        {
            //set your MongoDB running instance
            //simple code for a POC :) in real code this should go in a config file
            Server = new MongoServerAddress("192.168.99.100", 27017)
        };
        
        public void CommitChangesAsync(Event<T> @event)
        {
            _client = new MongoClient(mongoClientSettings);
            db = _client.GetDatabase(Db);

            //Here is real production code should be managed errors durng insert/publish with a 2PC protocol
            var collection = db.GetCollection<Event<T>>(@event.GetType().ToString());
            collection.InsertOne(@event);
            IEventPublisher<T> publisher = PubSubFactory<T>.GetDefault();
            publisher.PublishAsync(@event);
        }

        public IEnumerable<Event<T>> GetEvents(int start, int count)
        {
            throw new NotImplementedException();
        }

        public Task<Event<T>> GetLastEventAsync(Type aggregateType, Guid aggregateId)
        {
            throw new NotImplementedException();
        }
    }
}
