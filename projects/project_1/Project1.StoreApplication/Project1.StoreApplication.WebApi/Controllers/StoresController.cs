﻿using Microsoft.AspNetCore.Mvc;
using Project1.StoreApplication.Business;
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
        private StoreApp _app;
        public StoresController(StoreApp app)
        {
            _app = app;
        }

        [HttpGet]
        public async Task<List<Store>> GetStores()
        {
            return await _app.GetStores();
        }

        [HttpPost("add")]
        public async Task<Store> AddStore([FromForm] Store store)
        {
            return await _app.AddStore(store);
        }
    }
}
