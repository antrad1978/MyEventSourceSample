using EventStorage.Command;
using EventStorage;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Text;
using System;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace EventStore.PubSub
{
    public class RabbitMQEventManager<T> : IEventPublisher<T>
    {
        ConnectionFactory factory = new ConnectionFactory() { HostName = "192.168.99.100" };

        void IEventPublisher<T>.PublishAsync(Event<T> @event)
        {
            if (@event.EventPublishedName != null)
            {
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "orders", type: "fanout");

                    var json = new JavaScriptSerializer().Serialize(@event);
                    var body = Encoding.UTF8.GetBytes(json);
                    channel.BasicPublish(exchange: "orders",
                                                 routingKey: "",
                                                 basicProperties: null,
                                                 body: body);
                    Console.WriteLine(" [x] Sent {0}", json);
                }
            }
        }
    }
}
