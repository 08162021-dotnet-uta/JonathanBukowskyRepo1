using Microsoft.AspNetCore.Mvc;
using Project1.StoreApplication.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.StoreApplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IStorage _db;
        public LoginController(IStorage db)
        {
            _db = db;
        }

        [HttpPost]
        public int LogIn(string username, string password)
        {
            
        }
    }
}
