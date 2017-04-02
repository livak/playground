using IoT.GrainInterfaces.Messages;
using IoT.GrainInterfaces.Observers;
using Orleans;
using System.Threading.Tasks;

namespace IoT.GrainInterfaces
{
    public interface ISystemGrain : IGrainWithStringKey
    {
        Task SetTemperature(TemperatureReading reading);
        Task Subscribe(ISystemObserver observer);
        Task UnSubscribe(ISystemObserver observer);
    }
}
