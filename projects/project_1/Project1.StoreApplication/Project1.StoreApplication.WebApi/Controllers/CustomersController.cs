using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Project1.StoreApplication.Storage;
using Project1.StoreApplication.Models;
using Microsoft.EntityFrameworkCore;
using Project1.StoreApplication.Storage.DBConverters;
using Project1.StoreApplication.Business;

namespace Project1.StoreApplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private StoreApp _app;
        /*
        public Customers() : base()
        {
            _db = new StoreApplicationDB2Context();
        }
        */
        public CustomersController(StoreApp app) : base()
        {
            _app = app;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            //var custs = _db.Customers.FromSqlRaw("SELECT * FROM Customer.Customer");
            //var result = await (from c in custs select c.ConvertToModel()).ToListAsync();
            var result = await _app.GetCustomers();
            return result;
        }

        [HttpPost("add")]
        public async Task<Customer> AddCustomer([FromForm] Customer customer)
        {
            //TODO: Validation
            return await _app.AddCustomer(customer);
        }

    }
}
