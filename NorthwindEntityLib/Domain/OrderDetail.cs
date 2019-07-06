using NorthwindEntityLib;

namespace NorthwindContextLib
{
    public class OrderDetail : INorthwindDb
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public decimal UnitPrice { get; set; } = 0;
        public short Quantity { get; set; } = 1;
        public double Discount { get; set; } = 0;

        public int EntityId => OrderId;
    }
}
