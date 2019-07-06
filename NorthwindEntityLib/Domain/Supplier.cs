﻿using NorthwindEntityLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NorthwindContextLib
{
    public class Supplier : INorthwindDb
    {
        public Supplier()
        {
            this.Products = new Collection<Product>();
        }

        [Required]
        public int SupplierId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }
        public ICollection<Product> Products { get; set; }

        public int EntityId => SupplierId;
    }
}
