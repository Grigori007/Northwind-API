using NorthwindEntityLib;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindContextLib
{
    public class ProductDto : INorthwindDb
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public SupplierDto Supplier { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;

        public int EntityId => ProductId;
    }
}
