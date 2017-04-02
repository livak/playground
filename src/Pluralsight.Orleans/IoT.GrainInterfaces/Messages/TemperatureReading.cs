using Orleans.Concurrency;
using System;

namespace IoT.GrainInterfaces.Messages
{
    [Immutable]
    public class TemperatureReading
    {
        public double Value { get; set; }
        public long DeviceId { get; set; }
        public DateTime Time { get; set; }
    }
}
