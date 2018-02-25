using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStorage
{
    public class Snapshot<T>
    {
        public Guid Id { get; set; }
        public String AggregateId { get; set; }
        public int Version { get; set; }
        public T Item { get; set; }

        public Snapshot()
        {

        }

        public Snapshot(Guid id, string aggregateId, int version) : base()
        {
            Id = id;
            AggregateId = aggregateId;
            Version = version;
        }
    }
}
