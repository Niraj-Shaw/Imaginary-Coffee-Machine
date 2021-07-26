using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeMachineResponse.Interfaces;
using CoffeeMachineResponse.Repositories;
using CoffeeMachineResponse.Models;
using Microsoft.Extensions.Caching.Memory;
using CoffeeMachineResponse.CustomExceptionsFilter;

namespace Imaginary_Coffee_Machine.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoffeeMachineController : ControllerBase
    {
        private IMemoryCache Cache;

        public CoffeeMachineController(IMemoryCache MemoryCache)
        {
            this.Cache = MemoryCache;
        }
       
        private ICoffeeMachine CoffeeMachine = new CoffeeMachine();
        [HttpGet("Brew-Coffee")]

        public ActionResult<MachineResponse> Get()
        {
            int RequestCount;
            dynamic MachineResponse =  null;
            Cache.TryGetValue("RequestCount", out RequestCount);
            RequestCount++;
            Cache.Set("RequestCount", RequestCount);

            try
            {
                MachineResponse = CoffeeMachine.GetResponse(RequestCount);
            }
            catch(Exception Ex) 
            {
                if (Ex is Status503Exception)
                    return StatusCode(503, "503 Service Unavailable");
                else if (Ex is Status418Exception)
                    return StatusCode(418, "418 I'm a teapot");

            }
            return MachineResponse;
        }
    }
}
