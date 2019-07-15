﻿using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindService.Repositories.Interfaces;
using System;
using System.Linq;

namespace NorthwindService.Repositories
{
    public class CustomersRepository : BaseRepository<Customer>, ICustomersRepository
    {
        public CustomersRepository(NorthwindDbContext _dbContext) : base(_dbContext)
        {
            dbContext.Customers.Include(p => p.Orders).ToList();
        }

        public Customer Get(string id)
        {
            id = id.ToUpper();
            return dbContext.Customers.Find(id);
        }

        public bool Remove(string id)
        {
            id = id.ToUpper();
            Customer customer = dbContext.Customers.Find(id);
            dbContext.Remove(customer);
            int changedEntities = dbContext.SaveChanges();
            if (changedEntities == 1)
            {
                return true;
            }
            return false;
        }
    }
}
