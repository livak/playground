using System.Threading.Tasks;
using Orleans;

namespace IoT.GrainInterfaces
{
    /// <summary>
    /// Grain interface IDeviceGrain
    /// </summary>
	public interface IDeviceGrain : IGrainWithIntegerKey
    {
        Task<double> GetTemperature();
        Task SetTemperature(double value);
        Task JoinSystem(string name);
    }
}
