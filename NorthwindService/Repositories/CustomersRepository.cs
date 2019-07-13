using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindService.Repositories
{
    public class CustomersRepository : BaseRepository<Customer>, ICustomersRepository
    {
        public CustomersRepository(NorthwindDbContext _dbContext) : base(_dbContext)
        {
        }

        public Customer Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
