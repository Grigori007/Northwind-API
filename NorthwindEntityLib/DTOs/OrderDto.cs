using NorthwindEntityLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NorthwindContextLib 
{
    public class OrderDto : INorthwindDb
    {
        public OrderDto()
        {
            this.OrderDetails = new Collection<OrderDetailDto>();
        }

        [Key]
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int ShippedVia { get; set; }
        public ShipperDto Shipper { get; set; }
        public decimal? Freight { get; set; } = 0;
        public ICollection<OrderDetailDto> OrderDetails { get; set; }

        public int EntityId => OrderId;
    }
}
