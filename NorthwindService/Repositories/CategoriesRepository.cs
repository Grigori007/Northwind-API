using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;

namespace NorthwindService.Repositories
{
    public class CategoriesRepository : BaseRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(NorthwindDbContext _context) : base(_context)
        {
        }
    }
}
