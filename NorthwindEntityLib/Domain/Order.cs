using NorthwindEntityLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NorthwindContextLib
{
    public class Order : INorthwindDb
    {
        public Order()
        {
            this.OrderDetails = new Collection<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int ShippVia { get; set; }
        public virtual Shipper Shipper { get; set; }
        public decimal? Freight { get; set; } = 0;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public int EntityId => OrderId;
    }
}
