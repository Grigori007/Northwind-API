using NorthwindEntityLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NorthwindContextLib
{
    public class Category : INorthwindDb
    {
        public Category()
        {
            this.Products = new Collection<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public int EntityId => CategoryId;
    }
}
