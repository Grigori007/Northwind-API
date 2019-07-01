﻿using NorthwindEntityLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NorthwindContextLib
{
    public class SupplierDto : INorthwindDb
    {
        public SupplierDto()
        {
            this.Products = new Collection<ProductDto>();
        }

        public int SupplierID { get; set; }
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
        public ICollection<ProductDto> Products { get; set; }

        public int EntityID => SupplierID;
    }
}
