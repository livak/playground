using IoT.GrainInterfaces.Observers;
using System;

namespace IoT.TestSilo.Observers
{
    public class SystemObserver : ISystemObserver
    {
        public void HighTemperature(double value, string name, int count)
        {
            Console.WriteLine($"System temperature is high (name: {name}, average: {value}, count: {count})");
        }
    }
}
