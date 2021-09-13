using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Project1.StoreApplication.Storage;
using Project1.StoreApplication.Models;
using Microsoft.EntityFrameworkCore;
using Project1.StoreApplication.Storage.DBConverters;

namespace Project1.StoreApplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private IStorage _db;
        /*
        public Customers() : base()
        {
            _db = new StoreApplicationDB2Context();
        }
        */
        public CustomersController(IStorage db) : base()
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetTodoItems()
        {
            //var custs = _db.Customers.FromSqlRaw("SELECT * FROM Customer.Customer");
            //var result = await (from c in custs select c.ConvertToModel()).ToListAsync();
            var result = await _db.GetCustomers();
            return result;
        }

        [HttpPost("add")]
        public async Task<Boolean> AddCustomer([FromForm] Customer customer)
        {
            //TODO: Validation
            return await _db.AddCustomer(customer);
        }

    }
}
