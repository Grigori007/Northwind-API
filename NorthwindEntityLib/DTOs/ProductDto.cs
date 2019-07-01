using NorthwindEntityLib;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindContextLib
{
    public class ProductDto : INorthwindDb
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public SupplierDto Supplier { get; set; }
        public int? CategoryID { get; set; }
        public CategoryDto Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool IsDiscontinued { get; set; } = false;

        public int EntityID => ProductID;
    }
}
