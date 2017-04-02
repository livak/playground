using IoT.GrainInterfaces;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoT.GrainInterfaces.Messages;

namespace IoT.GrainClasses
{
    public class SystemGrain : Grain, ISystemGrain
    {
        Dictionary<long, double> temperatures;

        public override Task OnActivateAsync()
        {
            temperatures = new Dictionary<long, double>();
            return base.OnActivateAsync();
        }

        public Task SetTemperature(TemperatureReading reading)
        {
            temperatures[reading.DeviceId] = reading.Value;

            double avg = temperatures.Values.Average();
            if (avg > 100)
            {
                Console.WriteLine($"System temperature is high (name: {this.GetPrimaryKeyString()}, average: {avg}, count: {temperatures.Count})");
            }

            return TaskDone.Done;
        }
    }
}
