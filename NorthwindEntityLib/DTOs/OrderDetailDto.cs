using NorthwindEntityLib;

namespace NorthwindContextLib
{
    public class OrderDetailDto : INorthwindDb
    {
        public int OrderID { get; set; }
        public OrderDto Order { get; set; }
        public int ProductID { get; set; }
        public ProductDto Product { get; set; }
        public decimal UnitPrice { get; set; } = 0;
        public short Quantity { get; set; } = 1;
        public double Discount { get; set; } = 0;

        public int EntityID => OrderID;
    }
}
