using IoT.GrainInterfaces;
using Orleans;
using Orleans.Concurrency;
using System.Threading.Tasks;

namespace IoT.GrainClasses
{
    [Reentrant]
    [StatelessWorker]
    public class DecodeGrain : Grain, IDecodeGrain
    {
        public async Task Decode(string message)
        {
            var parts = message.Split(',');
            var grain = GrainFactory.GetGrain<IDeviceGrain>(int.Parse(parts[0]));
            await grain.SetTemperature(double.Parse(parts[1]));
        }
    }
}
