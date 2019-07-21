﻿using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : GenericController<OrderDetail>
    {
        private readonly OrderDetailsRepository _convertedRepo;

        public OrderDetailsController(IBaseRepository<OrderDetail> repo) : base(repo)
        {
            _convertedRepo = (OrderDetailsRepository)_repository;
        }

        [HttpGet("{id:int}")]
        public override async Task<IActionResult> ReadOneEntity(int id)
        {
            IEnumerable<OrderDetail> orderDetails = await _convertedRepo.Get(id);
            if (!orderDetails.Any())
            {
                return NotFound();
            }
            return new ObjectResult(orderDetails);        
        }

        [HttpDelete("{id:int}")]
        public override async Task<bool>
            
        
    }
}