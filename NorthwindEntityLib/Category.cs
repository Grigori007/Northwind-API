using NorthwindEntityLib;
using System.Collections.Generic;

namespace NorthwindContextLib
{
    public class Category : INorthwindDb
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }

        public int EntityID => CategoryID;
    }
}
