using NorthwindEntityLib;
using System.ComponentModel.DataAnnotations;

namespace NorthwindContextLib
{
    public class Product : INorthwindDb
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        [Required]
        public bool Discontinued { get; set; } = false;

        public dynamic EntityId => ProductId;
    }
}
