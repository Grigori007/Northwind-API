using NorthwindEntityLib;
using System.Collections.Generic;

namespace NorthwindContextLib
{
    public class CategoryDto : INorthwindDb
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<ProductDto> Products { get; set; }

        public int EntityID => CategoryID;
    }
}
