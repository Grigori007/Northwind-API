﻿using Newtonsoft.Json;
using NorthwindEntityLib;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindContextLib
{
    public class Product : IBaseEntity
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Maximum length is 40 characters!")]
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        [StringLength(20, ErrorMessage = "Maximum length is 20 characters!")]
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        [Required]
        public bool Discontinued { get; set; } = false;

        [NotMapped]
        [JsonIgnore]
        public dynamic EntityId => ProductId;
    }
}
