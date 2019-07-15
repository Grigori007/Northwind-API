using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using System.Linq;

namespace NorthwindService.Repositories
{
    public class CategoriesRepository : BaseRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(NorthwindDbContext _context) : base(_context)
        {
            dbContext.Categories.Include(p => p.Products).ToList();
        }
    }
}
