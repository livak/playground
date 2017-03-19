using System.Threading.Tasks;
using Orleans;

namespace IoT.GrainInterfaces
{
    /// <summary>
    /// Grain interface IDeviceGrain
    /// </summary>
	public interface IDeviceGrain : IGrainWithIntegerKey
    {
        Task SetTemperature(double value);
    }
}