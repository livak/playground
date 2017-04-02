using System.Threading.Tasks;
using Orleans;
using IoT.GrainInterfaces;
using System;
using Orleans.Providers;
using Orleans.Concurrency;
using IoT.GrainInterfaces.Messages;

namespace IoT.GrainClasses
{
    public class IDeviceGrainState
    {
        public double LastValue { get; set; }
        public string System { get; set; }
    }
     
    [Reentrant]
    [StorageProvider(ProviderName = "file")]
    public class DeviceGrain : Grain<IDeviceGrainState>, IDeviceGrain
    {
        public DeviceGrain()
        {

        }

        public async Task JoinSystem(string name)
        {
            State.System = name;
            await WriteStateAsync();
        }

        public override Task OnActivateAsync()
        {
            var id = this.GetPrimaryKeyLong();
            Console.WriteLine($"Activated {id}");
            Console.WriteLine($"Activated state = {State.LastValue}");
            return base.OnActivateAsync();
        }

        public async Task SetTemperature(double value)
        {
            if (State.LastValue < 100 && value >= 100)
            {
                Console.WriteLine($"High temperature recorded: {value}, device {this.GetPrimaryKeyLong()}");
            }
            if (State.LastValue != value)
            {
                State.LastValue = value;
                await WriteStateAsync();
            }

            var systemGrain = GrainFactory.GetGrain<ISystemGrain>(State.System);
            TemperatureReading temperatureReading = new TemperatureReading()
            {
                Value = value,
                DeviceId = this.GetPrimaryKeyLong(),
                Time = DateTime.Now
            };
            await systemGrain.SetTemperature(temperatureReading);
        }
    }
}
