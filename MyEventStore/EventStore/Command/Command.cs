using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStorage
{
    public class Command<T>
    {
        public Guid CorrelationId { get; private set; }
        public string Aggregate { get; }
        public int TargetVersion { get; private set; }
        public T Item { get; set; }
        public List<object> OtherParameters { get; set; } 

        public Command(Guid CorrelationId, string aggregateId, int targetVersion)
        {
            this.CorrelationId = CorrelationId;
            Aggregate = aggregateId;
            TargetVersion = targetVersion;
        }
    }
}
