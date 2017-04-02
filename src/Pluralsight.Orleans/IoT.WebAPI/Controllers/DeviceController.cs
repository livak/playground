using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Orleans;
using IoT.GrainInterfaces;

namespace IoT.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DeviceController : Controller
    {
        [HttpGet("{id}")]
        public Task<double> Get(long id)
        {

            var grain = GrainClient.GrainFactory.GetGrain<IDeviceGrain>(id);
            return grain.GetTemperature();
        }

        [HttpPost]
        public Task Post([FromBody] string message)
        {
            var grain = GrainClient.GrainFactory.GetGrain<IDecodeGrain>(0);
            return grain.Decode(message);
        }
    }
}
