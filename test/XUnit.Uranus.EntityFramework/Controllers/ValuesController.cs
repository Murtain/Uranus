﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XUnit.Uranus.EntityFramework.ApplicationServices;
using Uranus.Domain.UnitOfWork;
using Uranus.EntityFramework.Provider;
using Microsoft.EntityFrameworkCore;

namespace XUnit.Uranus.EntityFramework.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IServiceBarApplicationService serviceBarApplicationService;
        private readonly IUnitOfWorkManager unitOfWorkManager;
        private readonly IEntityFrameworkDbContextProvider<ModelsContainer> entityFrameworkDbContextProvider;
        public ValuesController(IEntityFrameworkDbContextProvider<ModelsContainer> entityFrameworkDbContextProvider,IUnitOfWorkManager unitOfWorkManager,IServiceBarApplicationService serviceBarApplicationService)
        {
            this.entityFrameworkDbContextProvider = entityFrameworkDbContextProvider;
            this.unitOfWorkManager = unitOfWorkManager;
            this.serviceBarApplicationService = serviceBarApplicationService;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<SDK.ServiceBar>> GetAsync()
        {
            using (var uow = unitOfWorkManager.Begin())
            {
                
                var entities = await serviceBarApplicationService.ServiceBarGetCollectionAsync("","");

                return entities;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
