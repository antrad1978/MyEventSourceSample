using EventStorage;
using EventStore.Event;
using Ngt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Order order = CreateOrder();
            EventStorage.Event<Order> @event = new Event<Order>();
            @event.AggregateType = "Order";
            @event.AggregateValue = order;
            @event.EventVersion = 1;
            @event.EventPublishedName = "NewOrder";
            IEventStorage<Order> storage = EventStorageFactory<Order>.GetDefaultEventStorage();
            storage.CommitChangesAsync(@event);
        }

        private static Order CreateOrder()
        {
            Order order = new Order();
            Customer customer = new Customer();
            customer.CustomerName = "tonio";
            customer.CustomerId = Guid.NewGuid();
            customer.Address = "Address";
            order.Customer = customer;
            order.OrderId = Guid.NewGuid();
            OrderDetail detail = new OrderDetail();
            detail.Description = "product";
            detail.RowTotal = 100;
            detail.Um = "KG";
            List<OrderDetail> details = new List<OrderDetail>();
            details.Add(detail);
            order.Rows = details;
            return order;
        }
    }
}
