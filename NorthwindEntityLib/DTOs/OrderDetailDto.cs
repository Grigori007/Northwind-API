using NorthwindEntityLib;
using System.ComponentModel.DataAnnotations;

namespace NorthwindContextLib
{
    public class OrderDetailDto : INorthwindDb
    {
        [Key]
        public int OrderId { get; set; }
        public OrderDto Order { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public decimal UnitPrice { get; set; } = 0;
        public short Quantity { get; set; } = 1;
        public double Discount { get; set; } = 0;

        public int EntityId => OrderId;
    }
}
