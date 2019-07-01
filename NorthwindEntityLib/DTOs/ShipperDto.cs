using NorthwindEntityLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NorthwindContextLib
{
    public class ShipperDto : INorthwindDb
    {
        public ShipperDto()
        {
            this.Orders = new Collection<OrderDto>();
        }

        public int ShipperID { get; set; }
        public string ShipperName { get; set; }
        public string Phone { get; set; }
        public ICollection<OrderDto> Orders { get; set; }

        public int EntityID => ShipperID;
    }
}
