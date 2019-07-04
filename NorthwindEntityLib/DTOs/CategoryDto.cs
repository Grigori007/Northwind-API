using NorthwindEntityLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NorthwindContextLib
{
    public class CategoryDto : INorthwindDb
    {
        public CategoryDto()
        {
            this.Products = new Collection<ProductDto>();
        }

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<ProductDto> Products { get; set; }

        public int EntityId => CategoryId;
    }
}
