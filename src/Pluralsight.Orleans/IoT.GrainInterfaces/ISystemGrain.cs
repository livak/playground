using IoT.GrainInterfaces.Messages;
using Orleans;
using System.Threading.Tasks;

namespace IoT.GrainInterfaces
{
    public interface ISystemGrain : IGrainWithStringKey
    {
        Task SetTemperature(TemperatureReading reading);
    }
}
