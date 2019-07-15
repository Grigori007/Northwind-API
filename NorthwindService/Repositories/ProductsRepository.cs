using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NorthwindService.Repositories
{
    public class ProductsRepository : BaseRepository<Product>, IProducts
    {
        public ProductsRepository(NorthwindDbContext _dbContext) : base(_dbContext)
        {
            //dbContext.Products.Include(p => p.Supplier).ToList();
            //dbContext.Products.Include(p => p.Category).ToList();
        }
    }
}
