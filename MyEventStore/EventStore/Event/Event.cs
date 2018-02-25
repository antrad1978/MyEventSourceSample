using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventStorage
{
    public class Event<T>
    {
        public int EventVersion { get; set; }
        public String AggregateType { get; set; }
        public Guid CorrelationId { get; }
        public DateTime EventTimestamp { get; set; }
        public DateTime EventPublishedTimestamp { get; set; }
        public T AggregateValue { get; set; }
        public string EventPublishedName { get; set; }

        public Event()
        {
        }
    }
}
