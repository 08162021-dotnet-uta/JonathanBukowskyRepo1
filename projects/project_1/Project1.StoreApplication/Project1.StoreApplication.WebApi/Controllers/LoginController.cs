using Microsoft.AspNetCore.Mvc;
using Project1.StoreApplication.Business;
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
        private StoreApp _app;
        public LoginController(StoreApp app)
        {
            _app = app;
        }

        [HttpPost]
        public int LogIn(string username, string password)
        {
            throw new NotImplementedException("Login not implemented");
        }
    }
}
