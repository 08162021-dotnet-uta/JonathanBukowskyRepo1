using Microsoft.AspNetCore.Mvc;
using Project1.StoreApplication.Models;
using Project1.StoreApplication.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.StoreApplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IStorage _db;
        public ProductsController(IStorage db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            return await _db.GetProducts();
        }

        [HttpPost("add")]
        public async Task<bool> AddProduct([FromForm] Product product)
        {
            // TODO: add categories
            product.CategoryID = null;
            return _db.AddProduct(product);
        }
    }
}
