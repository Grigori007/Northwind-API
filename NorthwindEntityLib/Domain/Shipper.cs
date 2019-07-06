using NorthwindEntityLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NorthwindContextLib
{
    public class Shipper : INorthwindDb
    {
        public Shipper()
        {
            this.Orders = new Collection<Order>();
        }

        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public int EntityId => ShipperId;
    }
}
