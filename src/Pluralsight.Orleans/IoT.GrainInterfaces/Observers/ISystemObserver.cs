using Orleans;

namespace IoT.GrainInterfaces.Observers
{
    public interface ISystemObserver : IGrainObserver
    {
        void HighTemperature(double value, string name, int count);
    }
}
