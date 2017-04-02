using Orleans;
using Orleans.Concurrency;
using System.Threading.Tasks;

namespace IoT.GrainInterfaces
{
    public interface IDecodeGrain : IGrainWithIntegerKey
    {
        Task Decode(string message);
    }
}
