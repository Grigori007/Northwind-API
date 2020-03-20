using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NorthwindService.Repositories
{
    public class ProductsRepository : BaseRepository<Product>, IProductsRepository
    {
        public ProductsRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
            //dbContext.Products.Include(p => p.Supplier).ToList();
            //dbContext.Products.Include(p => p.Category).ToList();
        }
    }
}
