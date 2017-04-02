using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Orleans;
using IoT.GrainInterfaces;
using System.Linq;
using System.Collections.Generic;

namespace IoT.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        [HttpGet]
        public IEnumerable<int> GetAll()
        {
            return Enumerable.Range(0, 20);
        }

        [HttpGet("{id}")]
        public Task<double> Get(string id)
        {
            var grain = GrainClient.GrainFactory.GetGrain<ISystemGrain>(id);
            return grain.GetTemperature();
        }
    }
}
