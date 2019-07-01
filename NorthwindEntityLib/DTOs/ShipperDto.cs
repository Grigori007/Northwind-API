using NorthwindEntityLib;
using System.Collections.Generic;

namespace NorthwindContextLib
{
    public class ShipperDto : INorthwindDb
    {
        public int ShipperID { get; set; }
        public string ShipperName { get; set; }
        public string Phone { get; set; }
        public ICollection<OrderDto> Orders { get; set; }

        public int EntityID => ShipperID;
    }
}
