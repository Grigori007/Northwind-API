using NorthwindEntityLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindContextLib
{
    public class Order : IBaseEntity
    {
        public Order()
        {
            this.OrderDetails = new Collection<OrderDetail>();
        }

        [Required]
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        [Column("ShipVia")]
        public int? ShipperId { get; set; }
        public Shipper Shipper { get; set; }
        public decimal? Freight { get; set; } = 0;
        public ICollection<OrderDetail> OrderDetails { get; set; }

        [NotMapped]
        public dynamic EntityId => OrderId;
    }
}
