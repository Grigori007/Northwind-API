﻿using NorthwindEntityLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindContextLib
{
    public class Category : IBaseEntity
    {
        public Category()
        {
            this.Products = new Collection<Product>();
        }

        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }

        [NotMapped]
        public dynamic EntityId => CategoryId;
    }
}
