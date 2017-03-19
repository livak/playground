using System.Threading.Tasks;
using Orleans;
using IoT.GrainInterfaces;
using System;
using Orleans.Providers;

namespace IoT.GrainClasses
{
    public class IDeviceGrainState
    {
        public double LastValue { get; set; }
    }
     
    [StorageProvider(ProviderName = "file")]
    public class DeviceGrain : Grain<IDeviceGrainState>, IDeviceGrain
    {
        public DeviceGrain()
        {

        }
        public override Task OnActivateAsync()
        {
            var id = this.GetPrimaryKeyLong();
            Console.WriteLine("Activated {0}", id);
            Console.WriteLine("Activated state = {0}", this.State.LastValue);
            return base.OnActivateAsync();
        }

        public async Task SetTemperature(double value)
        {
            if (State.LastValue < 100 && value >= 100)
            {
                Console.WriteLine("High temperature recorded {0}", value);
            }
            if (State.LastValue != value)
            {
                State.LastValue = value;
                await WriteStateAsync();
            }
        }
    }
}
