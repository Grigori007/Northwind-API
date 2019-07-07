using NorthwindEntityLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NorthwindContextLib
{
    public class Shipper : INorthwindDb
    {
        public Shipper()
        {
            this.Orders = new Collection<Order>();
        }

        [Required]
        public int ShipperId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }

        public dynamic EntityId => ShipperId;
    }
}
