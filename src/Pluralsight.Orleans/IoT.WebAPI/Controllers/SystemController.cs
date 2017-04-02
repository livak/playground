using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Orleans;
using IoT.GrainInterfaces;

namespace IoT.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        [HttpGet("{id}")]
        public Task<double> Get(string id)
        {
            var grain = GrainClient.GrainFactory.GetGrain<ISystemGrain>(id);
            return grain.GetTemperature();
        }
    }
}
