using Newtonsoft.Json;
using NorthwindEntityLib;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindContextLib
{
    public class OrderDetail : IBaseEntity
    {
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public decimal UnitPrice { get; set; } = 0;
        [Required]
        public short Quantity { get; set; } = 1;
        [Required]
        public float Discount { get; set; } = 0;

        [JsonIgnore]
        [NotMapped]
        public dynamic EntityId => OrderId;
    }
}
