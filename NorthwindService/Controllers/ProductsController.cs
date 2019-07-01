using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindService.Repositories;
using NorthwindContextLib;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepoUniversal<ProductDto> uniRepo;

        public ProductsController(IRepoUniversal<ProductDto> _uniRepo)
        {
            uniRepo = _uniRepo;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> ReadProductsAsync()
        {
            return await uniRepo.ReadAllAsync();
        }


        // GET: api/products/[id]
        [HttpGet("{id}", Name = "ReadOneProductAsync")]
        public async Task<IActionResult> ReadOneProductAsync(int id)
        {
            ProductDto product = await uniRepo.ReadAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product); // 200 OK
        }


        // POST: api/products
        // BODY: Product(JSON, XML)
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            ProductDto added = await uniRepo.CreateAsync(product);
            return CreatedAtRoute("ReadOneProductAsync", new { id = added.ProductID }, product);
        }


        // PUT: api/products/[id]
        // BODY: Products(JSON, XML)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto product)
        {
            if (product == null || product.ProductID != id)
            {
                return BadRequest();
            }
            var existingProduct = await uniRepo.ReadAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            await uniRepo.UpdateAsync(id, product);
            return new NoContentResult();
        }


        // DELETE: api/products/[id]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await uniRepo.ReadAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            bool deletedProduct = await uniRepo.DeleteAsync(id);
            if (deletedProduct)
            {
                return new NoContentResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}