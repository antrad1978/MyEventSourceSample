using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ngt.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public IList<OrderDetail> Rows { get; set; }
    }
}
