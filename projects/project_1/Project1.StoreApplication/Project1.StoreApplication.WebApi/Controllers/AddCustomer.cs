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
    public class AddCustomer : ControllerBase
    {

        private IStorage _db;

        public AddCustomer(IStorage db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<Boolean> InsertCustomer([FromForm] Customer toAdd)
        {
            return _db.AddCustomer(toAdd);
        }
    }
}
