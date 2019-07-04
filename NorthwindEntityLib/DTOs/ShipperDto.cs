using NorthwindEntityLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NorthwindContextLib
{
    public class ShipperDto : INorthwindDb
    {
        public ShipperDto()
        {
            this.Orders = new Collection<OrderDto>();
        }

        [Key]
        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string Phone { get; set; }
        public ICollection<OrderDto> Orders { get; set; }

        public int EntityId => ShipperId;
    }
}
