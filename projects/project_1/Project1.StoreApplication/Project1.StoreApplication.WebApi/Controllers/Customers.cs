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
    public class Customers : ControllerBase
    {
        private IStorage _db;
        /*
        public Customers() : base()
        {
            _db = new StoreApplicationDB2Context();
        }
        */
        public Customers(IStorage db) : base()
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetTodoItems()
        {
            //var custs = _db.Customers.FromSqlRaw("SELECT * FROM Customer.Customer");
            //var result = await (from c in custs select c.ConvertToModel()).ToListAsync();
            var result = _db.GetCustomers();
            return result;
        }
    }
}
