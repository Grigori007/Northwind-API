using NorthwindEntityLib;
using System;
using System.Collections.Generic;

namespace NorthwindContextLib 
{
    public class OrderDto : INorthwindDb
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public CustomerDto Customer { get; set; }
        public int EmployeeID { get; set; }
        public EmployeeDto Employee { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int ShippedVia { get; set; }
        public ShipperDto Shipper { get; set; }
        public decimal? Freight { get; set; } = 0;
        public ICollection<OrderDetailDto> OrderDetails { get; set; }

        public int EntityID => OrderID;
    }
}
