using NorthwindEntityLib;
using System.ComponentModel.DataAnnotations;

namespace NorthwindContextLib
{
    public class OrderDetail : IBaseEntity
    {
        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public decimal UnitPrice { get; set; } = 0;
        public short Quantity { get; set; } = 1;
        [Required]
        public float Discount { get; set; } = 0;

        public dynamic EntityId => OrderId;
    }
}
