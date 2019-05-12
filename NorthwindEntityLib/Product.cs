﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindContextLib
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsInOrder { get; set; } = 0;
        public short? RecorderLevel { get; set; } = 0;
        public bool IsDiscontinued { get; set; } = false;
    }
}
