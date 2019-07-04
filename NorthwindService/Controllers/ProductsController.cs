﻿using Microsoft.AspNetCore.Mvc;
using NorthwindContextLib;
using NorthwindService.Repositories;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : GenericController<ProductDto>
    {
        public ProductsController(IBaseRepository<ProductDto> _productRepo) : base(_productRepo)
        {
        }
    }
}