using NorthwindEntityLib;
using System.Collections.Generic;

namespace NorthwindContextLib
{
    public class Shipper : INorthwindDb
    {
        public int ShipperID { get; set; }
        public string ShipperName { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }

        public int EntityID => ShipperID;
    }
}
