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
    public class StoresController : ControllerBase
    {
        private IStorage _db;
        public StoresController(IStorage db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<Store>> GetStores()
        {
            return _db.GetStores();
        }

        [HttpPost("add")]
        public async Task<bool> AddStore([FromForm] Store store)
        {
            return _db.AddStore(store);
        }
    }
}
